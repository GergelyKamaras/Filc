using Filc.Services.DataBaseQueryServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Route("api/user")]
    public class UserApiController
    {
        private readonly UserService _userService;
        public UserApiController(UserService userService)
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
