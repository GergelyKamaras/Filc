using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.DataBaseQueryServices;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [EnableCors]
    [ApiController]
    [Route("api/users")]
    [Authorize(Roles = "Government")]
    public class UserApiController : Controller
    {
        private readonly IUserServiceFullAccess _userService;
        public UserApiController(IUserServiceFullAccess userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<ApplicationUser> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
    }
}
