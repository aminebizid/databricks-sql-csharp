// Copyright (C) 2018  Samuel Fisher
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Transport;
using Thrift.Transport.Client;
using static DataBricks.Sql.Sasl.EndianEncoding;

namespace DataBricks.Sql.Sasl
{
    /// <summary>
    /// Wraps an ITransport, performing SASL negotiation when Open() is called.
    /// </summary>
    public class TSaslClientTransport : TTransport
    {
        private const int StatusBytes = 1;
        private const int PayloadLengthBytes = 4;
        private const int MessageHeaderLength = StatusBytes + PayloadLengthBytes;

        private readonly SaslNegotiator saslNegotiator;
        private readonly TSocketTransport socket;
        private readonly MemoryStream writeBuffer = new MemoryStream();
        private readonly TMemoryInputTransport readBuffer = new TMemoryInputTransport();

        private bool isOpen;

        public TSaslClientTransport(TSocketTransport socket, string userName, string password)
        {
            Configuration = new TConfiguration();
            saslNegotiator = new SaslNegotiator(new PlainMechanism(userName, password));
            this.socket = socket;
        }

        public override bool IsOpen => isOpen;
        public override TConfiguration Configuration { get; }

        // public override Task OpenAsync()
        // {
        //     return OpenAsync(CancellationToken.None);
        // }

        public override void UpdateKnownMessageSize(long size)
        {
            throw new System.NotImplementedException();
        }

        public override void CheckReadBytesAvailable(long numBytes)
        {
            // throw new System.NotImplementedException();
        }

        public override async Task OpenAsync(CancellationToken cancellationToken)
        {
            if (!IsOpen)
            {
                await socket.OpenAsync(cancellationToken);
                await SendSaslMessageAsync(SaslStatus.Start, Encoding.UTF8.GetBytes(saslNegotiator.MechanismName), cancellationToken);
                await SendSaslMessageAsync(SaslStatus.Ok, saslNegotiator.RespondToChallenge(null), cancellationToken);

                while (true)
                {
                    var result = await ReceiveSaslMessageAsync(cancellationToken);
                    if (result.Status == SaslStatus.Complete)
                    {
                        isOpen = true;
                        break;
                    }
                    else if (result.Status == SaslStatus.Ok)
                    {
                        await SendSaslMessageAsync(SaslStatus.Ok, saslNegotiator.RespondToChallenge(Encoding.UTF8.GetBytes(result.Body)), cancellationToken);
                    }
                    else
                    {
                        socket.Close();
                        throw new ProtocolViolationException($"Bad SASL negotiation status: {result.Status} ({result.Body})");
                    }
                }
            }
        }

        public override void Close()
        {
            socket.Close();
            isOpen = false;
        }
        

        public async Task SendSaslMessageAsync(SaslStatus status, byte[] body,
            CancellationToken cancellationToken = default)
        {
            var header = new byte[MessageHeaderLength];
            header[0] = (byte)status;
            EncodeBigEndian(body.Length, header, StatusBytes);
            await socket.WriteAsync(header, cancellationToken);
            await socket.WriteAsync(body, cancellationToken);
            await socket.FlushAsync(cancellationToken);
        }

        public async Task<SaslMessage> ReceiveSaslMessageAsync(CancellationToken cancellationToken = default)
        {
            var result = new SaslMessage();
            var header = new byte[MessageHeaderLength];
            await socket.ReadAllAsync(header, 0, header.Length, cancellationToken);
            result.Status = (SaslStatus)header[0];
            byte[] body = new byte[DecodeBigEndianInt32(header, StatusBytes)];
            await socket.ReadAllAsync(body, 0, body.Length, cancellationToken);

            result.Body = Encoding.UTF8.GetString(body);
            return result;
        }

        public async Task<int> ReadLengthAsync(CancellationToken cancellationToken = default)
        {
            byte[] lenBuf = new byte[4];
            await socket.ReadAllAsync(lenBuf, 0, lenBuf.Length, cancellationToken);
            return DecodeBigEndianInt32(lenBuf);
        }

        public async Task WriteLengthAsync(int length, CancellationToken cancellationToken = default)
        {
            byte[] lenBuf = new byte[4];
            EncodeBigEndian(length, lenBuf);
            await socket.WriteAsync(lenBuf, cancellationToken);
        }

        // public override ValueTask<int> ReadAsync(byte[] buf, int off, int len)
        // {
        //     return ReadAsync(buf, off, len, CancellationToken.None);
        // }

        public override async ValueTask<int> ReadAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken)
        {
            int readLength = await readBuffer.ReadAsync(buffer, offset, length);
            if (readLength > 0)
                return readLength;

            await ReadFrameAsync(cancellationToken);

            return await readBuffer.ReadAsync(buffer, offset, length);
        }

        private async Task ReadFrameAsync(CancellationToken cancellationToken = default)
        {
            int dataLength = await ReadLengthAsync(cancellationToken);
            if (dataLength < 0)
                throw new TTransportException($"Read a negative frame size ({dataLength}).");

            byte[] buff = new byte[dataLength];
            await socket.ReadAllAsync(buff, 0, dataLength, cancellationToken);
            readBuffer.Reset(buff);
        }

        public override Task WriteAsync(byte[] buf, int off, int len)
        {
            return WriteAsync(buf, off, len, CancellationToken.None);
        }

        public override Task WriteAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken)
        {
            writeBuffer.Write(buffer, offset, length);
            return Task.CompletedTask;
        }


        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            byte[] data = writeBuffer.ToArray();
            // Reset write buffer
            writeBuffer.SetLength(0);
            await WriteLengthAsync(data.Length, cancellationToken);
            await socket.WriteAsync(data, 0, data.Length, cancellationToken);
            await socket.FlushAsync(cancellationToken);
        }

        protected override void Dispose(bool disposing)
        {
            socket.Close();
        }
    }
}
