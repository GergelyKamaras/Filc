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

namespace Filc.Controllers
{
    [ApiController]
    [Route("authentication")]
    [AllowAnonymous]
    [EnableCors]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserServiceFullAccess _userService;

        public AccountController(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , RoleManager<IdentityRole> roleManager
            , IConfiguration configuration,
            IUserServiceFullAccess userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _userService = userService;
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
        [Route("register")]
        // Centrum
        public async Task<ObjectResult> Register(RegistrationModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = "User already exists!" });
            }

            ApplicationUser user = new ()
            { 
                UserName=model.Email,
                Email = model.Email,
                Salt = model.Salt,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   new JWTAuthenticationResponse { Status = "Error", Message = "User creation failed! Please check user details and try again" });
            }

            if (await _roleManager.RoleExistsAsync(model.Role))
            {
                await _userManager.AddToRoleAsync(user, model.Role);

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   new JWTAuthenticationResponse { Status = "Error", Message = "The specified Role is not valid" });
            }

            return Ok(new JWTAuthenticationResponse 
            { 
                Status = "Success",
                Message = "User created successfully!"
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
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaims);
                return Ok(new
                {

                    message = "SUCCESS",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                   new JWTAuthenticationResponse { Status = "Error", Message = "Account not valid" });;

        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
