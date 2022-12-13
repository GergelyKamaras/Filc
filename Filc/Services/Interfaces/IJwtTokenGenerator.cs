using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Filc.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public JwtSecurityToken GetToken(List<Claim> authClaims);
    }
}
