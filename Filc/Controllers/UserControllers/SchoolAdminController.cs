using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.UserControllers
{
    public class SchoolAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("register-new")]
        public IActionResult RegisterUser()
        {
            return View();
        }
    }
}
