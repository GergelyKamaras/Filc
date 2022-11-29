using Filc.Services.DataBaseQueryServices;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Route("api/users")]
    public class UserApiController
    {
        private readonly IUserServiceFullAccess _userService;
        public UserApiController(IUserServiceFullAccess userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<IdentityUser> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        [Route("first")]
        public IdentityUser GetFirstUser()
        {
            return _userService.GetAllUsers().First();
        }

    }
}
