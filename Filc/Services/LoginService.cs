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
                    if (userRole != "Government")
                        foreach(var userData in GetUserDatasClaim(model, userRole))
                        {
                            authClaims.Add(userData);
                        }
                }

                return _jwtTokenGenerator.GetToken(authClaims);
                
            }
            throw new Exception();
        }

        
        private List<Claim> GetUserDatasClaim(LoginModel model, string role)
        {
            List<Claim> userDatas = new();

            switch (role)
            {
                case "Teacher":
                    userDatas.Add(new Claim("schoolId",
                        _db.Teacher.Where(t => t.user.Email == model.Email)
                        .Select(t => t.School.Id).FirstOrDefault().ToString()));

                    userDatas.Add(new Claim("userId",
                        _db.Teacher.Where(t => t.user.Email == model.Email)
                        .Select(t => t.Id).FirstOrDefault().ToString()));

                    userDatas.Add(new Claim("userFirstName",
                        _db.Teacher.Where(t => t.user.Email == model.Email)
                        .Select(t => t.FirstName).First().ToString()));

                    userDatas.Add(new Claim("userLastName",
                        _db.Teacher.Where(t => t.user.Email == model.Email)
                        .Select(t => t.LastName).First().ToString()));

                    userDatas.Add(new Claim("userBithDate",
                        _db.Teacher.Where(t => t.user.Email == model.Email)
                        .Select(t => t.BirthDate).FirstOrDefault().ToString()));

                    return userDatas;

                case "SchoolAdmin":
                    
                    userDatas.Add(new Claim("schoolId",
                        _db.SchoolAdmin.Where(t => t.user.Email == model.Email)
                        .Select(t => t.School.Id).FirstOrDefault().ToString()));

                    userDatas.Add(new Claim("userId",
                        _db.SchoolAdmin.Where(t => t.user.Email == model.Email)
                        .Select(t => t.Id).FirstOrDefault().ToString()));

                    userDatas.Add(new Claim("userFirstName",
                        _db.SchoolAdmin.Where(t => t.user.Email == model.Email)
                        .Select(t => t.FirstName).First().ToString()));

                    userDatas.Add(new Claim("userLastName",
                        _db.SchoolAdmin.Where(t => t.user.Email == model.Email)
                        .Select(t => t.LastName).First().ToString()));

                    userDatas.Add(new Claim("userBithDate",
                        _db.SchoolAdmin.Where(t => t.user.Email == model.Email)
                        .Select(t => t.BirthDate).FirstOrDefault().ToString()));

                    return userDatas;

                case "Student":
                    
                    userDatas.Add(new Claim("schoolId",
                        _db.Student.Where(t => t.user.Email == model.Email)
                        .Select(t => t.School.Id).FirstOrDefault().ToString()));

                    userDatas.Add(new Claim("userId",
                        _db.Student.Where(t => t.user.Email == model.Email)
                        .Select(t => t.Id).FirstOrDefault().ToString()));

                    userDatas.Add(new Claim("userFirstName",
                        _db.Student.Where(t => t.user.Email == model.Email)
                        .Select(t => t.FirstName).First().ToString()));

                    userDatas.Add(new Claim("userLastName",
                        _db.Student.Where(t => t.user.Email == model.Email)
                        .Select(t => t.LastName).First().ToString()));

                    userDatas.Add(new Claim("userBithDate",
                        _db.Student.Where(t => t.user.Email == model.Email)
                        .Select(t => t.BirthDate).FirstOrDefault().ToString()));

                    return userDatas;
            }

            throw new Exception("Given Role does not exist ");

        }

    }
}
