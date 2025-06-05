using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace mythos_frontend_dotnet.Services
{
    public class JwtParser
    {
        public ClaimsPrincipal ParseClaimsFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            var identity = new ClaimsIdentity(token.Claims, "jwt");
            return new ClaimsPrincipal(identity);
        }
    }
}
