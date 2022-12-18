using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Protocol.Entities;

namespace DataBricks.Sql.ThriftApi.TCLService
{
   
    
    
    public abstract class TProtocolGateway
    {
        protected abstract Task<bool> ReadFieldAsync(TProtocol protocol, TField field, CancellationToken cancellationToken);

        protected abstract TGroup GetWritingGroup();
        
        
        public async Task ReadAsync(TProtocol protocol, CancellationToken cancellationToken = default)
        {
            await protocol.ReadStructAsync(async field =>
            {
                if (!await ReadFieldAsync(protocol, field, cancellationToken))
                    await protocol.SkipAsync(field, cancellationToken);
            }  ,cancellationToken);
            
        }
        
        public async Task WriteAsync(TProtocol protocol, CancellationToken cancellationToken = default)
        {
            await protocol.WriteStructAsync(GetWritingGroup(), cancellationToken);
        }
        
    }
}