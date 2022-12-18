using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataBricks.Sql.Auth;
using DataBricks.Sql.Auth.ThriftHttpClient;
using DataBricks.Sql.ThriftApi.TCLService.TTypes;
using Thrift.Protocol;

namespace DataBricks.Sql
{
    public class ThriftBackend
    {

        private readonly Dictionary<string, List<object>> _retry_policy = new Dictionary<string, List<object>>
        {
            {"_retry_delay_min", new List<object> { typeof(float), 1, 0.1, 60 }},
            {"_retry_delay_max", new List<object> { typeof(float), 60, 5, 3600 }},
            {"_retry_stop_after_attempts_count", new List<object> { typeof(int), 30, 1, 60 }},
            {"_retry_stop_after_attempts_duration", new List<object> { typeof(float), 900, 1, 86400 }},
            {"_retry_delay_default", new List<object> { typeof(float), 5, 1, 60 }}
        };

        private readonly Dictionary<string,object> _customParameters;
        private readonly Dictionary<string, double> _retryParameters = new ();
        private readonly THttpClient _transport;
        private readonly TCLIService.Client _client;

        public ThriftBackend(
            string hostname,
            string httpPath,
            Dictionary<string, string> headers,
            AuthProvider authProvider,
            int port = 443,
            Dictionary<string, object> customParameters = null)
        {
            var uri = new Uri($"https://{hostname}:{port}/{httpPath}");
            _customParameters = customParameters;
            
            _transport = new THttpClient(authProvider, uri, headers);
            _transport.SetCustomHeaders(headers);
            var protocol = new TBinaryProtocol(_transport);
            _client = new TCLIService.Client(protocol, protocol);
        }

        public async Task<TSessionHandle> OpenSessionAsync(Dictionary<string, object> sessionConfiguration, string catalog, string schema,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _transport.OpenAsync(cancellationToken);
            var sessionConfig = new Dictionary<string, string>();

            if (sessionConfiguration != null)
            {
                foreach (var kv in sessionConfiguration)
                {
                    sessionConfig[kv.Key] = kv.Value.ToString();
                }
            }

            sessionConfig["spark.thriftserver.arrowBasedRowSet.timestampAsString"] = "false";

            TNamespace initialNamespace = null;
            if (catalog != null || schema != null)
            {
                initialNamespace = new TNamespace{CatalogName = catalog, SchemaName = schema};
            }
            
            var openSessionRequest = new TOpenSessionReq{Client_protocol_i64 = 42246, InitialNamespace =  initialNamespace,
                Configuration = sessionConfig, CanUseMultipleCatalogs = true};
                

            var response = await MakeRequestAsync(_client.OpenSession, openSessionRequest, cancellationToken);

            return response.SessionHandle;
        }

        public async Task CloseSessionAsync(TSessionHandle sessionHandle, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var closeSessionRequest = new TCloseSessionReq{SessionHandle = sessionHandle};
            
            try
            {
                await MakeRequestAsync(_client.CloseSession, closeSessionRequest, cancellationToken);
            }
            finally
            {
                _transport.Close();
            }
        }

        private static async Task<T2> MakeRequestAsync<T1, T2>(
                                    Func<T1, CancellationToken, Task<T2>> methodAsync,
                                    T1 request,
                                    CancellationToken cancellationToken = default)
        {
            return await methodAsync(request, cancellationToken);
        }



        private void InitRetryPolicy()
        {
            foreach (var kv in _retry_policy)
            {
                var givenOrDefault = _customParameters.ContainsKey(kv.Key)
                    ? Convert.ChangeType(_customParameters[kv.Key], (Type)(kv.Value[0]))
                    : Convert.ChangeType(kv.Value[1], (Type)(kv.Value[0]));
                var bound = Bound((double)(kv.Value[3]), (double)(kv.Value[3]), (double)givenOrDefault);
                _retryParameters[kv.Key] = bound;
                
                //ToDo: Add checks
            }
        }

        private double Bound(double min, double max, double givenOrDefault)
        {
            return Math.Min(max, Math.Max(min, givenOrDefault));
        }

        public async Task<ExecuteResponse> ExecuteCommandAsync(
            string operation,
            TSessionHandle sessionHandler,
            int maxRows,
            int maxBytes,
            bool lz4Compression,
            bool canReadArrowResult = false,
            CancellationToken cancellationToken = default)
        {
            if (sessionHandler == null)
                throw new Exception("No session");

            var request = new TExecuteStatementReq{
                    SessionHandle =  sessionHandler,
                    Statement =  operation,
                    RunAsync = true,
                    GetDirectResults = new TSparkGetDirectResults{ MaxRows = maxRows, MaxBytes = maxBytes},
                    CanReadArrowResult = canReadArrowResult,
                    CanDecompressLZ4Result = lz4Compression,
                    CanDownloadResult = false,
                    ConfOverlay = new Dictionary<string, string>{{"spark.thriftserver.arrowBasedRowSet.timestampAsString", "false"}}
                };

            var response = await MakeRequestAsync(_client.ExecuteStatement, request, cancellationToken);

           
            return await HandleExecutionResponse(response);
        }

        private async Task<ExecuteResponse> HandleExecutionResponse(TExecuteStatementResp response)
        {
            var finalOperationState = await WaitUntilCommandDoneAsync(response.OperationHandle, response.DirectResults?.OperationStatus);

            return await ResultsMessageToExecuteResponse(response, finalOperationState);
        }

        private async Task<ExecuteResponse> ResultsMessageToExecuteResponse(TExecuteStatementResp resp, TOperationState? operationState)
        {
            TGetResultSetMetadataResp tResultMetadata;
            if (resp.DirectResults?.ResultSetMetadata != null)
            {
                tResultMetadata = resp.DirectResults.ResultSetMetadata;
            }
            else tResultMetadata = await GetMetadataRespAsync(resp.OperationHandle);

            if (tResultMetadata == null)
                throw new Exception("Unable to get metadata");
            var directResults = resp.DirectResults;
            var hasBeenClosedServerSide = directResults?.CloseOperation;
            var hasMoreRows = directResults?.ResultSet == null || directResults?.ResultSet?.HasMoreRows == true;
            var lz4Compressed = tResultMetadata.Lz4Compressed;

            return new ExecuteResponse
            {
                Status = operationState,
                HasBeenClosedServerSide = hasBeenClosedServerSide,
                HasMoreRows = hasMoreRows,
                Lz4Compressed = lz4Compressed,
                CommandHandle = resp.OperationHandle,
                Results = directResults?.ResultSet?.Results,
                Schema  = tResultMetadata?.Schema,
                ArrowSchema = tResultMetadata?.ArrowSchema
            };

        }

        private async Task<TGetResultSetMetadataResp> GetMetadataRespAsync(TOperationHandle operationHandle)
        {
            var req = new TGetResultSetMetadataReq
            {
                OperationHandle = operationHandle
            };
            return await MakeRequestAsync(_client.GetResultSetMetadata, req);
        }

        private async Task<TOperationState?> WaitUntilCommandDoneAsync(TOperationHandle opHandle, TGetOperationStatusResp initialOperationStatusResponse)
        {
            if (initialOperationStatusResponse != null)
            {
                CheckCommandNotInErrorOrClosedState(opHandle, initialOperationStatusResponse);
            }

            var operationState = initialOperationStatusResponse?.OperationState;

            while (operationState == null || operationState == TOperationState.RUNNING_STATE || operationState == TOperationState.PENDING_STATE)
            {
                var pollResp = await PollForStatusAsync(opHandle);
                operationState = pollResp.OperationState;
                CheckCommandNotInErrorOrClosedState(opHandle, pollResp);
                await Task.Delay(200);
            }

            return operationState;
        }

        private async Task<TGetOperationStatusResp> PollForStatusAsync(TOperationHandle opHandle)
        {
            var req = new TGetOperationStatusReq { OperationHandle = opHandle, GetProgressUpdate = false};
            return await MakeRequestAsync(_client.GetOperationStatus, req);
        }

        private void CheckCommandNotInErrorOrClosedState(TOperationHandle opHandle, TGetOperationStatusResp getOperationResp)
        {
            if (getOperationResp.OperationState == TOperationState.ERROR_STATE)
            {
                if (getOperationResp.DisplayMessage != null)
                {
                    throw new Exception(getOperationResp.DisplayMessage);
                }
                throw new Exception("error CheckCommandNotInErrorOrClosedState");
            }

            if (getOperationResp.OperationState == TOperationState.CLOSED_STATE)
            {
                throw new Exception("Connection closed");
            }
            
            
        }

        public async Task<TFetchResultsResp> FetchResultsAsync(TOperationHandle opHandle, int maxRows, int maxBytes, int expectedRowStartOffset, CancellationToken cancellationToken = default )
        {
            var req = new TFetchResultsReq
            {
                OperationHandle = new TOperationHandle 
                    {
                        OperationId = opHandle.OperationId,
                        OperationType = opHandle.OperationType,
                        HasResultSet = false,
                        ModifiedRowCount = opHandle.ModifiedRowCount
                    },
                MaxRows = maxRows,
                MaxBytes = maxBytes,
                Orientation = (int)TFetchOrientation.FETCH_NEXT
            };

            var resp = await MakeRequestAsync(_client.FetchResults, req, cancellationToken);

            if (resp.Results.StartRowOffset > expectedRowStartOffset)
            {
                Console.WriteLine($"Expected results to start from {expectedRowStartOffset} but they instead start at {resp.Results.StartRowOffset}");
            }

            return resp;
        }

        public async Task CloseCommandAsync(TOperationHandle opHandle, CancellationToken cancellationToken)
        {
            var req = new TCloseOperationReq { OperationHandle = opHandle };
            await MakeRequestAsync(_client.CloseOperation, req, cancellationToken);
        }
    }
}