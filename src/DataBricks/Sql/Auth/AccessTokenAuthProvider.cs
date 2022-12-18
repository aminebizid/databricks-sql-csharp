using System.Collections.Generic;

namespace DataBricks.Sql.Auth
{
    public class AccessTokenAuthProvider : AuthProvider
    {
        private readonly string _authorizationHeaderValue;

        public AccessTokenAuthProvider(string accessToken)
        {
            _authorizationHeaderValue = $"Bearer {accessToken}";
        }
        
        public override void AddHeaders(Dictionary<string, string> headers)
        {
            headers["Authorization"] = _authorizationHeaderValue;
        }
    }
}