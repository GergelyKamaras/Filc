using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Filc.ViewModel;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Filc.Models.JWTAuthenticationModel;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Filc.Models.AuthenticationModels;
using Filc.Services;
using Filc.Services.Interfaces;
using Serilog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Filc.Controllers.Apis
{
    [ApiController]
    [Route("authentication")]
    [AllowAnonymous]
    [EnableCors]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserServiceFullAccess _userService;
        private readonly ILogin _loginService;

        public AccountController(SignInManager<ApplicationUser> signInManager,
                                 IUserServiceFullAccess userService,
                                 ILogin loginService)
        {
            _signInManager = signInManager;
            _userService = userService;
            _loginService = loginService;
        }

        [HttpPost]
        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            await _signInManager.SignOutAsync();
            CustomLogger.LogRequest(token, "Signed out");
            return Ok(new JWTAuthenticationResponse
            {
                Status = "Success",
                Message = "You Logged out!"
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {

                var token = await _loginService.Login(model);
                Log.Information($"Logged in as {model.Email}");
                return Ok(new
                {
                    message = "SUCCESS",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch (Exception e)
            {
                Log.Error("Error logging in" + e);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   new JWTAuthenticationResponse { Status = e.ToString(), Message = "Invalid email/password" });
            }
        }
    }
}