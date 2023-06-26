using System.Collections.Generic;

namespace HiveClient.Sql.Auth
{
    public abstract class AuthProvider
    {
        public abstract void AddHeaders(Dictionary<string, string> headers);
    }
}