using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace DataBricks.Sql.Sasl
{
    public class TSocketClientTransport : TStreamClientTransport
    {
        private bool _isDisposed;

        public TSocketClientTransport(TcpClient client)
        {
            TcpClient = client ?? throw new ArgumentNullException(nameof(client));

            if (IsOpen)
            {
                InputStream = client.GetStream();
                OutputStream = client.GetStream();
            }
        }

        public TSocketClientTransport(IPAddress host, int port)
            : this(host, port, 0)
        {
        }

        public TSocketClientTransport(IPAddress host, int port, int timeout)
        {
            Host = host;
            Port = port;

            TcpClient = new TcpClient();
            TcpClient.ReceiveTimeout = TcpClient.SendTimeout = timeout;
            TcpClient.Client.NoDelay = true;
        }

        public TcpClient TcpClient { get; private set; }
        public IPAddress Host { get; }
        public int Port { get; }

        public int Timeout
        {
            set
            {
                if (TcpClient != null)
                {
                    TcpClient.ReceiveTimeout = TcpClient.SendTimeout = value;
                }
            }
        }

        public override bool IsOpen
        {
            get
            {
                if (TcpClient == null)
                {
                    return false;
                }

                return TcpClient.Connected;
            }
        }

        public override async Task OpenAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                await Task.FromCanceled(cancellationToken);
            }

            if (IsOpen)
            {
                throw new TTransportException(TTransportException.ExceptionType.AlreadyOpen, "Socket already connected");
            }

            if (Port <= 0)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen, "Cannot open without port");
            }

            if (TcpClient == null)
            {
                throw new InvalidOperationException("Invalid or not initialized tcp client");
            }

            await TcpClient.ConnectAsync(Host, Port);

            InputStream = TcpClient.GetStream();
            OutputStream = TcpClient.GetStream();
        }

        public override void Close()
        {
            base.Close();

            if (TcpClient != null)
            {
                TcpClient.Dispose();
                TcpClient = null;
            }
        }

        // IDisposable
        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    TcpClient?.Dispose();

                    base.Dispose(disposing);
                }
            }
            _isDisposed = true;
        }
    }
}