using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataBricks.Sql.Auth;
using DataBricks.Sql.ThriftApi.TCLService.TTypes;

namespace DataBricks.Sql
{
    public class Connection
    {
        private const string UserAgent = "PyDatabricksSqlConnector/2.2.1";
        
        public bool IsOpen;
        private readonly string _hostname;
        private readonly Dictionary<string, object> _customParameters;
        private readonly AccessTokenAuthProvider _authProvider;
        private ThriftBackend _thriftBackend;
        public TSessionHandle SessionHandler;
        private readonly string _httpPath;
        private readonly Dictionary<string, string> _headers;
        private readonly string _catalog;
        private readonly string _schema;
        private readonly Dictionary<string, object> _sessionConfiguration;

        public Connection(
            string hostname,
            string httpPath,
            string accessToken,
            Dictionary<string, string> httpHeaders = null,
            Dictionary<string, object> sessionConfiguration = null,
            string catalog = null,
            string schema = null,
            Dictionary<string, object> customParameters = null)
        {

             IsOpen = false;
             _hostname = hostname;
             _httpPath = httpPath;
             _catalog = catalog;
             _schema = schema;
             _sessionConfiguration = sessionConfiguration;
             _customParameters = customParameters ?? new Dictionary<string, object>();
             _customParameters["access_token"] = accessToken;
             var port = _customParameters.ContainsKey("port") ? (int)customParameters["port"] : 443;
             _authProvider = new AccessTokenAuthProvider(accessToken);

             var useragentHeader = !_customParameters.ContainsKey("_user_agent_entry") ? UserAgent : $"{UserAgent} ({_customParameters["_user_agent_entry"]})";

             _headers = new Dictionary<string, string> { {"User-Agent", useragentHeader} };

             if (httpHeaders == null) return;
             foreach (var (key, value) in httpHeaders)
                 _headers[key] = value;
             
            

        }

        public async Task OpenAsync(CancellationToken cancellationToken)
        {
            _thriftBackend = new ThriftBackend(
                _hostname,
                _httpPath,
                _headers,
                _authProvider,
                customParameters: _customParameters
            );
            SessionHandler = await _thriftBackend.OpenSessionAsync(_sessionConfiguration, _catalog, _schema, cancellationToken);
            IsOpen = true;
            
        }

        public Cursor GetCursor(int BufferSizeByte = 10485760, int mawRows = 100000, bool canReadArrowResult = false, bool canReadCompressed = false)
        {
            return new Cursor(this, _thriftBackend, BufferSizeByte, mawRows, canReadArrowResult, compressed: canReadCompressed);
        }

        public async Task ReOpenAsync(CancellationToken cancellationToken)
        {
            await CloseSessionAsync(cancellationToken);
            await OpenAsync(cancellationToken);
        }

        public async Task CloseSessionAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _thriftBackend.CloseSessionAsync(SessionHandler, cancellationToken);
            IsOpen = false;
        }
    }
}