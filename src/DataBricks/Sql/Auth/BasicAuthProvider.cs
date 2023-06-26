using System;
using System.Collections.Generic;
using System.Text;

namespace DataBricks.Sql.Auth
{
    public class BasicAuthProvider : AuthProvider
    {
        private readonly string _authorizationHeaderValue;

        public BasicAuthProvider(string user, string password)
        {
            _authorizationHeaderValue = "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{user}:{password}"));;
        }
        
        public override void AddHeaders(Dictionary<string, string> headers)
        {
            headers["Authorization"] = _authorizationHeaderValue; 

        }

      
    }
}