using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataBricks.Sql.ThriftApi.TCLService.TTypes;

namespace DataBricks.Sql
{
    public class ArrowResultSet : IResultSet
    {
        private readonly Connection _connection;
        private readonly TOperationHandle _commandId;
        private TOperationState? _opState;
        private TCloseOperationResp _hasBeenClosedServerSide;
        private readonly int _bufferSizeByte;
        private readonly int _arraySize;
        private readonly ThriftBackend _thriftBackend;
        private int _nextRowIndex;
        private readonly Queue<object[]> _queue;
        private readonly byte[] _arrowSchema;
        private readonly bool _isCompressed;
        public bool HasMoreRows { get; set; }

        public ArrowResultSet(Connection connection, ExecuteResponse executeResponse, ThriftBackend thriftBackend,
            int bufferSizeByte, int arraySize, Queue<object[]> queue)
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
            _arrowSchema = executeResponse.ArrowSchema;
            _isCompressed = executeResponse.Lz4Compressed;
            _nextRowIndex = ArrowToQueueAsync(executeResponse.Results).Result;
        }

        public async Task GetRemainingAsync()
        {
            while (HasMoreRows)
            {
                var resp  = await _thriftBackend.FetchResultsAsync(_commandId, _arraySize, _bufferSizeByte, _nextRowIndex);
                HasMoreRows = resp.HasMoreRows;
                _nextRowIndex += await ArrowToQueueAsync(resp.Results);
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
                _hasBeenClosedServerSide = null;
                _opState = TOperationState.CLOSED_STATE;
            }
        }

        private async Task<int> ArrowToQueueAsync(TRowSet rowSet,
            CancellationToken cancellationToken = default)
        {
            var count = await ArrowHelper.FillQueueAsync(rowSet, _arrowSchema, _isCompressed, _queue, cancellationToken);
           
            if (HasMoreRows) return count;
            lock (_queue)
            {
                _queue.Enqueue(null);
            }

            return count;
        }
    }
}