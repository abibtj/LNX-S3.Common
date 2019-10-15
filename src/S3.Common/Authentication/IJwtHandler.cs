using System.Collections.Generic;

namespace S3.Common.Authentication
{
    public interface IJwtHandler
    {
        JsonWebToken CreateToken(string userId, string[] roles = null, IDictionary<string, string> claims = null);
        JsonWebTokenPayload GetTokenPayload(string accessToken);
    }
}