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
using Filc.Services.Interfaces;

namespace Filc.Controllers
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
            await _signInManager.SignOutAsync();
            return Ok(new JWTAuthenticationResponse
            {
                Status = "Success",
                Message = "You Logged out!"
            });
        }

        [HttpPost]
        [Route("loginsalt")]
        public ObjectResult GetLoginSalt(EmailModel model)
        {
            
            return Ok(new 
            {
                Status = "Success",
                Message = _userService.GetSaltByEmail(model.Email)
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var token = await _loginService.Login(model);
                return Ok(new
                {
                    message = "SUCCESS",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   new JWTAuthenticationResponse { Status = e.ToString(), Message = "Account not valid" });
            }
        }
        
    }
}