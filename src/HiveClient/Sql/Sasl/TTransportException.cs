using Thrift;

namespace HiveClient.Sql.Sasl
{
    public class TTransportException : TException
    {
        public enum ExceptionType
        {
            Unknown,
            NotOpen,
            AlreadyOpen,
            TimedOut,
            EndOfFile,
            Interrupted
        }

        protected ExceptionType ExType;

        public TTransportException()
        {
        }

        public TTransportException(ExceptionType exType)
            : this()
        {
            ExType = exType;
        }

        public TTransportException(ExceptionType exType, string message)
            : base(message, null)
        {
            ExType = exType;
        }

        public TTransportException(string message)
            : base(message, null)
        {
        }

        public ExceptionType Type => ExType;
    }
}