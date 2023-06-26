using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HiveClient.Sql.ThriftApi.TCLService.TTypes;

namespace HiveClient.Sql
{
    public class ColumnsResultSet : IResultSet
    {
        private readonly int[] _bitMasks = {
            1, 2, 4, 8, 16, 32, 64, 128
        };
        
        private readonly Connection _connection;
        private readonly TOperationHandle _commandId;
        private TOperationState? _opState;
        private TCloseOperationResp _hasBeenClosedServerSide;
        public bool HasMoreRows { get; set; }
        private readonly int _bufferSizeByte;
        private readonly int _arraySize;
        private readonly ThriftBackend _thriftBackend;
        private int _nextRowIndex;
        private TRowSet _results;
        private TTableSchema _schema;
        private object[][] _arrayRows;
        private List<Func<TColumn, (IList, byte[])>> _lambdas;
        private readonly ConcurrentQueue<object[]> _queue;

        public ColumnsResultSet(Connection connection, ExecuteResponse executeResponse, ThriftBackend thriftBackend, int bufferSizeByte, int arraySize, ConcurrentQueue<object[]> queue)
        {
            _connection = connection;
            _commandId = executeResponse.CommandHandle;
            _opState = executeResponse.Status;
            _hasBeenClosedServerSide = executeResponse.HasBeenClosedServerSide;
            HasMoreRows = executeResponse.HasMoreRows;
            _bufferSizeByte = bufferSizeByte;
            _arraySize = arraySize;
            _thriftBackend = thriftBackend;
            _nextRowIndex = 0;
            _queue = queue;
           
            if (executeResponse.Schema == null)
            {
                throw new Exception("Could not get schema");
            }

            _schema = executeResponse.Schema;
            MakeLambdas();
            _results = executeResponse.Results;
            ColsToArrayRows();
            _nextRowIndex += _arrayRows.Length;

            FillQueue();
        }
        
        public async Task GetRemainingAsync()
        {
            while (HasMoreRows)
            {
                await FillResultsBufferAsync();
                FillQueue();
            }
        }
        
        public async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                if (_opState != TOperationState.CLOSED_STATE && _hasBeenClosedServerSide == null && _connection.IsOpen)
                    await _thriftBackend.CloseCommandAsync(_commandId, cancellationToken);
            }
            finally
            {
                _arrayRows = null;
                _hasBeenClosedServerSide = null;
                _opState = TOperationState.CLOSED_STATE;
            }
        }


        private void FillQueue()
        {
            foreach (var row in _arrayRows)
            {
                _queue.Enqueue(row);
            }
            if (!HasMoreRows) _queue.Enqueue(null);

            _arrayRows = null;

        }
        private void ColsToArrayRows()
        {
            var columnsCount = _results.Columns.Count;
            _arrayRows = new object[_arraySize][];
            int? receivedRowsCount = null;
            

            for (var i = 0; i < columnsCount; i++)
            {
                var col = _results.Columns[i];
                var (values, nulls) = _lambdas[i](col);
                if (receivedRowsCount == null)
                    receivedRowsCount = values.Count;
                
                SetNullValues(values, nulls);
           
                for (var j = 0; j < values.Count; j++)
                {
                    if (i == 0)
                        _arrayRows[j] = new object[columnsCount];

                    _arrayRows[j][i] = values[j];
                }
            }
            
            Array.Resize(ref _arrayRows, receivedRowsCount??0);
        }

        private void SetNullValues(IList values, byte[] nulls)
        {
            var length = Math.Min(values.Count, nulls.Length * 8);
            for (var i = 0; i < length; i++)
            {
                if ((nulls[i >> 3] & _bitMasks[i & 0x7]) == 1)
                {
                    values[i] = null;
                }
            }
        }

        private void MakeLambdas()
        {
            _lambdas = new List<Func<TColumn, (IList, byte[])>>();

            foreach (var columnDesc in _schema.Columns)
            {
                switch (columnDesc.TypeDesc?.Types?[0].PrimitiveEntry?.Type)
                {
                    case TTypeId.INT_TYPE:
                        _lambdas.Add((column => (column.I32Val?.Values, column.I32Val?.Nulls)));
                        break;
                    case TTypeId.BOOLEAN_TYPE:
                        _lambdas.Add((column => (column.BoolVal?.Values, column.BoolVal?.Nulls)));
                        break;
                         
                    case TTypeId.TINYINT_TYPE:
                        _lambdas.Add((column => (column.ByteVal?.Values, column.ByteVal?.Nulls)));
                        break;
                    case TTypeId.SMALLINT_TYPE:
                        _lambdas.Add((column => (column.I16Val?.Values, column.I16Val?.Nulls)));
                        break;
                    case TTypeId.BIGINT_TYPE:
                        _lambdas.Add((column => (column.I64Val?.Values, column.I64Val?.Nulls)));
                        break;
                    case TTypeId.DOUBLE_TYPE:
                        _lambdas.Add((column => (column.DoubleVal?.Values, column.DoubleVal?.Nulls)));
                        break;
                    case TTypeId.STRING_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.TIMESTAMP_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.BINARY_TYPE:
                        _lambdas.Add((column => (column.BinaryVal?.Values, column.BinaryVal?.Nulls)));
                        break;
                    case TTypeId.DECIMAL_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.NULL_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.DATE_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.VARCHAR_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.CHAR_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.INTERVAL_YEAR_MONTH_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.INTERVAL_DAY_TIME_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.FLOAT_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.ARRAY_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.MAP_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.STRUCT_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    case TTypeId.UNION_TYPE:
                        _lambdas.Add((column => (column.BoolVal?.Values, column.BoolVal?.Nulls)));
                        break;
                    case TTypeId.USER_DEFINED_TYPE:
                        _lambdas.Add((column => (column.StringVal?.Values, column.StringVal?.Nulls)));
                        break;
                    default:
                        throw new Exception(
                            $"Unknown column type {columnDesc.TypeDesc?.Types?[0].PrimitiveEntry?.Type}");
                }
            }
        }

        private async Task FillResultsBufferAsync()
        {
            var resp  = await _thriftBackend.FetchResultsAsync(_commandId, _arraySize, _bufferSizeByte, _nextRowIndex);
            _results = resp.Results;
            if (_schema == null)
                if (resp.ResultSetMetadata?.Schema == null)
                    throw new Exception("Schema not provided");
                else
                {
                    _schema = resp.ResultSetMetadata.Schema;
                    MakeLambdas();
                }
            HasMoreRows = resp.HasMoreRows;
            ColsToArrayRows();
            _nextRowIndex += _arrayRows.Length;
        }

      
      
    }

}