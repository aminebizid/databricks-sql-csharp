using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Apache.Arrow;
using Apache.Arrow.Ipc;
using Apache.Arrow.Types;
using DataBricks.Sql.ThriftApi.TCLService.TTypes;
using IonKiwi.lz4;
using Microsoft.Data.Analysis;

namespace DataBricks.Sql
{
    public static class ArrowHelper
    {
        public static async Task<int> FillQueueAsync(TRowSet rowSet, byte[] arrowSchema, bool isCompressed, Queue<object[]> queue, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var count = 0;
            using var arrowStreamReader = GetArrowStreamReader(rowSet, arrowSchema, isCompressed);
            var recordBatch = await arrowStreamReader.ReadNextRecordBatchAsync(cancellationToken);
            while (recordBatch != null)
            {
                count += BatchToQueue(queue, recordBatch);
                recordBatch = await arrowStreamReader.ReadNextRecordBatchAsync(cancellationToken);
            }

            return count;
        }

        private static int BatchToQueue(Queue<object[]> queue, RecordBatch recordBatch)
        {
            var df = ArrowHelper.RecordBatchToDataFrame(recordBatch);
            var count = 0;

            lock (queue)
            {
                foreach (var row in df.Rows)
                {
                    var e = new object[row.Count()];
                    var index = 0;
                    foreach (var col in row)  e[index++] = col;
                    queue.Enqueue(e);
                    count++;
                }
            }

            return count;


        }
        private static ArrowStreamReader GetArrowStreamReader(TRowSet rowSet, byte[] arrowSchema, bool isCompressed)
        {
            var data = isCompressed ? UnCompress(rowSet, arrowSchema): GetBytes(rowSet, arrowSchema);
            return new ArrowStreamReader(new ReadOnlyMemory<byte>(data));
        }

        private static byte[] GetBytes(TRowSet rowSet, byte[] arrowSchema)
        {
            var data = new byte[arrowSchema.Length];
            arrowSchema.CopyTo(data, 0);
            var index = arrowSchema.Length;
            foreach (var arrowBatch in rowSet.ArrowBatches)
            {
                var batch = arrowBatch.Batch;
                var length = batch.Length;
                System.Array.Resize(ref data, data.Length + length);
                batch.CopyTo(data, index);
                index += length;
            }

            return data;
        }

        private static byte[] UnCompress(TRowSet rowSet, byte[] arrowSchema)
        {
            var tasks = new Task<byte[]>[rowSet.ArrowBatches.Count];
            var i = 0;
            foreach (var arrowBatch in rowSet.ArrowBatches)
            {
                tasks[i++] = Task<byte[]>.Factory.StartNew((o) => LZ4Utility.Decompress((byte[])o), arrowBatch.Batch);
            }

            Task.WaitAll(tasks);
            
            var arraySize = arrowSchema.Length + tasks.Sum(task => task.Result.Length);
            var data = new byte[arraySize];
            arrowSchema.CopyTo(data, 0);
            var arrayOffset = arrowSchema.Length;

            foreach (var task in tasks)
            {
                task.Result.CopyTo(data, arrayOffset);
                arrayOffset += task.Result.Length;
            }

            return data;
        }


        private static DataFrame RecordBatchToDataFrame(RecordBatch recordBatch)
        {
            var df = new DataFrame(System.Array.Empty<DataFrameColumn>());
            var i = 0;
            var schema = recordBatch.Schema;
            
            foreach (var array in recordBatch.Arrays)
            {
                var field = schema.GetFieldByIndex(i);
                var dataFrameColumn = MakeColumn(array, field);
                df.Columns.Insert(df.Columns.Count, dataFrameColumn);
                i++;
            }

            return df;
        }

       
         private static DataFrameColumn MakeColumn(IArrowArray arrowArray, Field field)
        {   
            
            var dataType = field.DataType;
            var name = field.Name;
            switch (dataType.TypeId)
            {
                case ArrowTypeId.Boolean:
                  var booleanArray = (BooleanArray) arrowArray;
                  var memory1 = booleanArray.ValueBuffer.Memory;
                  var memory2 = booleanArray.NullBitmapBuffer.Memory;
                  return new BooleanDataFrameColumn(name, memory1, memory2, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.UInt8:
                  var primitiveArray1 = (PrimitiveArray<byte>) arrowArray;
                  var memory3 = primitiveArray1.ValueBuffer.Memory;
                  var memory4 = primitiveArray1.NullBitmapBuffer.Memory;
                  return new ByteDataFrameColumn(name, memory3, memory4, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.Int8:
                  var primitiveArray2 = (PrimitiveArray<sbyte>) arrowArray;
                  var memory5 = primitiveArray2.ValueBuffer.Memory;
                  var memory6 = primitiveArray2.NullBitmapBuffer.Memory;
                  return new SByteDataFrameColumn(name, memory5, memory6, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.UInt16:
                  var primitiveArray3 = (PrimitiveArray<ushort>) arrowArray;
                  var memory7 = primitiveArray3.ValueBuffer.Memory;
                  var memory8 = primitiveArray3.NullBitmapBuffer.Memory;
                  return new UInt16DataFrameColumn(name, memory7, memory8, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.Int16:
                  var primitiveArray4 = (PrimitiveArray<short>) arrowArray;
                  var memory9 = primitiveArray4.ValueBuffer.Memory;
                  var memory10 = primitiveArray4.NullBitmapBuffer.Memory;
                  return new Int16DataFrameColumn(name, memory9, memory10, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.UInt32:
                  var primitiveArray5 = (PrimitiveArray<uint>) arrowArray;
                  var memory11 = primitiveArray5.ValueBuffer.Memory;
                  var memory12 = primitiveArray5.NullBitmapBuffer.Memory;
                  return new UInt32DataFrameColumn(name, memory11, memory12, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.Int32:
                  var primitiveArray6 = (PrimitiveArray<int>) arrowArray;
                  var memory13 = primitiveArray6.ValueBuffer.Memory;
                  var memory14 = primitiveArray6.NullBitmapBuffer.Memory;
                  return new Int32DataFrameColumn(name, memory13, memory14, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.UInt64:
                  var primitiveArray7 = (PrimitiveArray<ulong>) arrowArray;
                  var memory15 = primitiveArray7.ValueBuffer.Memory;
                  var memory16 = primitiveArray7.NullBitmapBuffer.Memory;
                  return new UInt64DataFrameColumn(name, memory15, memory16, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.Int64:
                  var primitiveArray8 = (PrimitiveArray<long>) arrowArray;
                  var memory17 = primitiveArray8.ValueBuffer.Memory;
                  var memory18 = primitiveArray8.NullBitmapBuffer.Memory;
                  return new Int64DataFrameColumn(name, memory17, memory18, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.Float:
                  var primitiveArray9 = (PrimitiveArray<float>) arrowArray;
                  var memory19 = primitiveArray9.ValueBuffer.Memory;
                  var memory20 = primitiveArray9.NullBitmapBuffer.Memory;
                  return new SingleDataFrameColumn(name, memory19, memory20, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.Double:
                  var primitiveArray10 = (PrimitiveArray<double>) arrowArray;
                  var memory21 = primitiveArray10.ValueBuffer.Memory;
                  var memory22 = primitiveArray10.NullBitmapBuffer.Memory;
                  return new DoubleDataFrameColumn(name, memory21, memory22, arrowArray.Length, arrowArray.NullCount);
                case ArrowTypeId.String:
                      var stringArray = (StringArray) arrowArray;
                      var memory23 = stringArray.ValueBuffer.Memory;
                      var arrowBuffer = stringArray.ValueOffsetsBuffer;
                      var memory24 = arrowBuffer.Memory;
                      arrowBuffer = stringArray.NullBitmapBuffer;
                      var memory25 = arrowBuffer.Memory;
                      return new ArrowStringDataFrameColumn(name, memory23, memory24, memory25, stringArray.Length, stringArray.NullCount);
                
                case ArrowTypeId.Timestamp: 
                    var primitiveArray11 = (PrimitiveArray<long>) arrowArray;
                    var memory26 = primitiveArray11.ValueBuffer.Memory;
                    var memory27 = primitiveArray11.NullBitmapBuffer.Memory;
                    return new UInt64DataFrameColumn(name, memory26, memory27, arrowArray.Length, arrowArray.NullCount);

                default:
                  throw new NotImplementedException(dataType.Name ?? "");
          }

        }
    }
}