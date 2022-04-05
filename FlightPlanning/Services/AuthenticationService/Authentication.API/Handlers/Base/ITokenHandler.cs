using System;

namespace Authentication.API.Handlers.Base
{
    public interface ITokenHandler
    {
        string IssueToken(string userName, string password, string signInKey);
    }
}