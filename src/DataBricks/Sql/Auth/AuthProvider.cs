using System.Collections.Generic;

namespace DataBricks.Sql.Auth
{
    public abstract class AuthProvider
    {
        public abstract void AddHeaders(Dictionary<string, string> headers);
    }
}