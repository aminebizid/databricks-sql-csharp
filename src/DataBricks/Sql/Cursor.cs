using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DataBricks.Sql
{
    public class Cursor : IDisposable
    {
        private readonly Connection _connection;
        private readonly ThriftBackend _thriftBackend;
        private readonly int _resultBufferSizeByte;
        private readonly int _arraySize;
        private bool _isOpen;
        private IResultSet _activeResultSet;

        private readonly Queue<object[]> _queue;
        private readonly bool _canReadArrowResult;
        private readonly bool _compressed;

        public Cursor(
            Connection connection,
            ThriftBackend thriftBackend,
            int resultBufferSizeByte = 10485760,
            int arraySize = 100000,
            bool canReadArrowResult = false,
            bool compressed = false
            )
        {
            _connection = connection;
            _thriftBackend = thriftBackend;
            _resultBufferSizeByte = resultBufferSizeByte;
            _arraySize = arraySize;
            _canReadArrowResult = canReadArrowResult;
            _compressed = compressed;
            _isOpen = true;
            _queue = new Queue<object[]>(arraySize + 1);
        }

        public async Task ExecuteAsync(string operation, CancellationToken cancellationToken = default)
        {
            lock (_queue)
            {
                _queue.Clear();
            }
            CheckIfNoteClosed();
            await CloseAndClearActiveResultSetAsync(cancellationToken);

            ExecuteResponse executeResponse;
            try
            {
                executeResponse = await _thriftBackend.ExecuteCommandAsync(
                    operation,
                    _connection.SessionHandler,
                    _arraySize,
                    _resultBufferSizeByte,
                    _compressed,
                    canReadArrowResult: _canReadArrowResult,
                    cancellationToken
                );
            }
            catch
            {
                await _connection.ReOpenAsync(cancellationToken);
                
                executeResponse = await _thriftBackend.ExecuteCommandAsync(
                    operation,
                    _connection.SessionHandler,
                    _arraySize,
                    _resultBufferSizeByte,
                    _compressed,
                    canReadArrowResult: _canReadArrowResult,
                    cancellationToken
                );
            }
           
            // In this case, the warehouse sent us a response but without results
            // We need to call back the warehouse to fetch the first results batch
            if (executeResponse.Results == null)
            {
                var resp  = await _thriftBackend.FetchResultsAsync(executeResponse.CommandHandle, _arraySize, _resultBufferSizeByte, 0, cancellationToken);
                executeResponse.Results = resp.Results;
                executeResponse.HasMoreRows = resp.HasMoreRows;
            }

            if (executeResponse.Results.Columns != null)
            {
                _activeResultSet = new ColumnsResultSet(_connection, executeResponse, _thriftBackend, _resultBufferSizeByte, _arraySize, _queue);
            }

            if (executeResponse.ArrowSchema != null)
            {
                _activeResultSet = new ArrowResultSet(_connection, executeResponse, _thriftBackend, _resultBufferSizeByte, _arraySize, _queue);
            }

            if (_activeResultSet == null)
                throw new Exception("No ResultSet");
            
            // Fetch all remaining results in a background
            if (_activeResultSet.HasMoreRows)
                Task.Factory.StartNew( async () => _activeResultSet.GetRemainingAsync(),
                    TaskCreationOptions.LongRunning).ConfigureAwait(false);
            
            
           
        }

       

        public async IAsyncEnumerable<object[]> GetRowAsync(int timeout = 180000,  [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (true)
            {
                if (sw.ElapsedMilliseconds > timeout)
                {
                    sw.Stop();
                    throw new Exception("Timeout");
                }
                bool found;
                object[] rowMessage;
                lock (_queue)
                {
                    found = _queue.TryDequeue(out rowMessage);
                }
              
                if (!found)
                {
                    await Task.Delay(200, cancellationToken);
                    continue;
                }

                if (rowMessage == null)
                {
                    sw.Stop();
                    yield break;
                }
                
                sw.Restart();
                yield return rowMessage;
            }
        }

        private async Task CloseAndClearActiveResultSetAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                if (_activeResultSet != null) await _activeResultSet.CloseAsync(cancellationToken);
            }
            finally
            {
                _activeResultSet = null;
            }
          
        }

        private void CheckIfNoteClosed()
        {
            if (!_isOpen)
                throw new Exception("Attempting operation on closed cursor");
        }

        public void Dispose()
        {
            CloseAsync().Wait();
        }

        public async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            _isOpen = false;
            if (_activeResultSet != null)
            {
                await CloseAndClearActiveResultSetAsync(cancellationToken);
            }
        }
    }
}