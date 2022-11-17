using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.UserControllers
{
    [Route("/govadmin")]
    public class GovAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/register-new")]
        [Route("/school")]
        public IActionResult RegisterSchool()
        {
            return View();
        }
        [Route("/admin")]
        public IActionResult RegisterAdmin()
        {
            return View();
        }
    }
}
