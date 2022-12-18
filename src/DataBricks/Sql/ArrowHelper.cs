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
        public static async IAsyncEnumerable<DataFrame> GetRecordBatchesAsync(TRowSet rowSet, byte[] arrowSchema, bool isCompressed, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            using var arrowStreamReader = GetArrowStreamReader(rowSet, arrowSchema, isCompressed);
            var recordBatch = await arrowStreamReader.ReadNextRecordBatchAsync(cancellationToken);
            while (recordBatch != null)
            {
                var df = ArrowHelper.RecordBatchToDataFrame(recordBatch);
                yield return df;
                recordBatch = await arrowStreamReader.ReadNextRecordBatchAsync(cancellationToken);
            }
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
            var tasks = new List<Task<byte[]>>();
            foreach (var arrowBatch in rowSet.ArrowBatches)
            {
                tasks.Add(Task<byte[]>.Factory.StartNew((o) => LZ4Utility.Decompress((byte[])o), arrowBatch.Batch));
            }

            var taskArray = tasks.ToArray();
            Task.WaitAll(taskArray);
            var size = arrowSchema.Length + taskArray.Sum(task => task.Result.Length);
            var data = new byte[size];
            arrowSchema.CopyTo(data, 0);
            var index = arrowSchema.Length;

            foreach (var task in taskArray)
            {
                task.Result.CopyTo(data, index);
                index += task.Result.Length;
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
            DataFrameColumn dataFrameColumn = (DataFrameColumn) null;
            switch (dataType.TypeId)
          {
            case ArrowTypeId.Boolean:
              BooleanArray booleanArray = (BooleanArray) arrowArray;
              ReadOnlyMemory<byte> memory1 = booleanArray.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory2 = booleanArray.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new BooleanDataFrameColumn(name, memory1, memory2, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.UInt8:
              PrimitiveArray<byte> primitiveArray1 = (PrimitiveArray<byte>) arrowArray;
              ReadOnlyMemory<byte> memory3 = primitiveArray1.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory4 = primitiveArray1.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new ByteDataFrameColumn(name, memory3, memory4, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.Int8:
              PrimitiveArray<sbyte> primitiveArray2 = (PrimitiveArray<sbyte>) arrowArray;
              ReadOnlyMemory<byte> memory5 = primitiveArray2.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory6 = primitiveArray2.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new SByteDataFrameColumn(name, memory5, memory6, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.UInt16:
              PrimitiveArray<ushort> primitiveArray3 = (PrimitiveArray<ushort>) arrowArray;
              ReadOnlyMemory<byte> memory7 = primitiveArray3.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory8 = primitiveArray3.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new UInt16DataFrameColumn(name, memory7, memory8, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.Int16:
              PrimitiveArray<short> primitiveArray4 = (PrimitiveArray<short>) arrowArray;
              ReadOnlyMemory<byte> memory9 = primitiveArray4.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory10 = primitiveArray4.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new Int16DataFrameColumn(name, memory9, memory10, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.UInt32:
              PrimitiveArray<uint> primitiveArray5 = (PrimitiveArray<uint>) arrowArray;
              ReadOnlyMemory<byte> memory11 = primitiveArray5.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory12 = primitiveArray5.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new UInt32DataFrameColumn(name, memory11, memory12, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.Int32:
              PrimitiveArray<int> primitiveArray6 = (PrimitiveArray<int>) arrowArray;
              ReadOnlyMemory<byte> memory13 = primitiveArray6.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory14 = primitiveArray6.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new Int32DataFrameColumn(name, memory13, memory14, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.UInt64:
              PrimitiveArray<ulong> primitiveArray7 = (PrimitiveArray<ulong>) arrowArray;
              ReadOnlyMemory<byte> memory15 = primitiveArray7.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory16 = primitiveArray7.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new UInt64DataFrameColumn(name, memory15, memory16, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.Int64:
              PrimitiveArray<long> primitiveArray8 = (PrimitiveArray<long>) arrowArray;
              ReadOnlyMemory<byte> memory17 = primitiveArray8.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory18 = primitiveArray8.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new Int64DataFrameColumn(name, memory17, memory18, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.Float:
              PrimitiveArray<float> primitiveArray9 = (PrimitiveArray<float>) arrowArray;
              ReadOnlyMemory<byte> memory19 = primitiveArray9.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory20 = primitiveArray9.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new SingleDataFrameColumn(name, memory19, memory20, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.Double:
              PrimitiveArray<double> primitiveArray10 = (PrimitiveArray<double>) arrowArray;
              ReadOnlyMemory<byte> memory21 = primitiveArray10.ValueBuffer.Memory;
              ReadOnlyMemory<byte> memory22 = primitiveArray10.NullBitmapBuffer.Memory;
              dataFrameColumn = (DataFrameColumn) new DoubleDataFrameColumn(name, memory21, memory22, arrowArray.Length, arrowArray.NullCount);
              break;
            case ArrowTypeId.String:
                  var stringArray = (StringArray) arrowArray;
                  var memory23 = stringArray.ValueBuffer.Memory;
                  ArrowBuffer arrowBuffer = stringArray.ValueOffsetsBuffer;
                  ReadOnlyMemory<byte> memory24 = arrowBuffer.Memory;
                  arrowBuffer = stringArray.NullBitmapBuffer;
                  ReadOnlyMemory<byte> memory25 = arrowBuffer.Memory;
                  dataFrameColumn = new ArrowStringDataFrameColumn(name, memory23, memory24, memory25, stringArray.Length, stringArray.NullCount);
                  break;
            
            case ArrowTypeId.Timestamp: 
                var primitiveArray11 = (PrimitiveArray<long>) arrowArray;
                var memory26 = primitiveArray11.ValueBuffer.Memory;
                var memory27 = primitiveArray11.NullBitmapBuffer.Memory;
                dataFrameColumn = new UInt64DataFrameColumn(name, memory26, memory27, arrowArray.Length, arrowArray.NullCount);
                break;

            default:
              throw new NotImplementedException(dataType.Name ?? "");
          }

          return dataFrameColumn;
        }

        

    }
}