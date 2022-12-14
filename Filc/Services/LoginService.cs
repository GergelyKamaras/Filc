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
                    if (userRole != "GovernmentAdmin")
                        authClaims.Add(GetShoolIdClaim(model, userRole));
                }

                return _jwtTokenGenerator.GetToken(authClaims);
                
            }
            throw new Exception();
        }

        private Claim GetShoolIdClaim(LoginModel model, string role)
        {
            switch (role)
            {
                case "Teacher":
                    return new Claim(role,
                        _db.Teacher.Where(t => t.user.Email == model.Email)
                        .Select(t => t.School.Id).FirstOrDefault().ToString());

                case "SchoolAdmin":
                    return new Claim(role,
                        _db.SchoolAdmin.Where(t => t.user.Email == model.Email)
                        .Select(t => t.School.Id).FirstOrDefault().ToString());

                case "Student":
                    return new Claim(role,
                        _db.Student.Where(t => t.user.Email == model.Email)
                        .Select(t => t.School.Id).FirstOrDefault().ToString());

            }
            throw new Exception("Given Role does not exist ");

        }

    }
}
