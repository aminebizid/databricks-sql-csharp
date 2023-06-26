#nullable enable
using HiveClient.Sql.ThriftApi.TCLService.TTypes;

namespace HiveClient.Sql
{
    public class ExecuteResponse
    {
        public TOperationState? Status { get; set; }
        public TCloseOperationResp? HasBeenClosedServerSide { get; set; }
        public bool HasMoreRows { get; set; }
        public bool Lz4Compressed { get; set; }
        public TOperationHandle? CommandHandle { get; set; }
        public TRowSet? Results { get; set; }
        public TTableSchema? Schema { get; set; }

        public byte[]? ArrowSchema;

    }
}