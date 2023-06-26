using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Transport.Client;

namespace HiveClient.Sql.Auth.ThriftHttpClient
{
    public class THttpClient : THttpTransport
    {
        private readonly AuthProvider _authProvider;
        private Dictionary<string, string> _headers;

        public THttpClient(AuthProvider authProvider, Uri host, IDictionary<string, string> headers) : base(host, new TConfiguration(), headers)
        {
            _authProvider = authProvider;
        }

        public void SetCustomHeaders(Dictionary<string, string> headers)
        {
            _headers = headers;
            foreach (var kv in headers)
            {
                if (RequestHeaders.Contains(kv.Key)) RequestHeaders.Remove(kv.Key);
                RequestHeaders.Add(kv.Key, kv.Value);
            }
           
        }

        public override async Task FlushAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            _authProvider.AddHeaders(_headers);
            SetCustomHeaders(_headers);
            await base.FlushAsync(cancellationToken);
        }

       
    }
}