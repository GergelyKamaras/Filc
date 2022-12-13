using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces;
using Filc.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Filc.Services
{
    public class LoginService : ILogin
    {
        private readonly ESContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginService(ESContext esContext,UserManager<ApplicationUser> userManager, IJwtTokenGenerator JwtTokenGenerator)
        {
            _db = esContext;
            _userManager = userManager;
            _jwtTokenGenerator = JwtTokenGenerator;
        }
        public async Task<JwtSecurityToken> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                authClaims.Add(GetShoolIdClaim(model));

                return _jwtTokenGenerator.GetToken(authClaims);
                
            }
            throw new Exception();
        }

        private Claim GetShoolIdClaim(LoginModel model)
        {
            string claimKey = "schoolId";
            return model.Role switch
            {
                "Teacher" => new Claim(claimKey,
                                        _db.Teacher.Where(t => t.user.Email == model.Email)
                                        .Select(t => t.School.Id).First().ToString()),

                "SchoolAdmin" => new Claim(claimKey,
                                        _db.SchoolAdmin.Where(t => t.user.Email == model.Email)
                                        .Select(t => t.School.Id).First().ToString()),

                "Student" => new Claim(claimKey,
                                        _db.Student.Where(t => t.user.Email == model.Email)
                                        .Select(t => t.School.Id).First().ToString()),

                _ => throw new Exception("Given Role does not exist"),
            };
        }

    }
}
