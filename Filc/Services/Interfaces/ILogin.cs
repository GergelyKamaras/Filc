using Filc.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Filc.Services.Interfaces
{
    public interface ILogin
    {
        public Task<JwtSecurityToken> Login(LoginModel model);
    }
}
