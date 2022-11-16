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
    }
}
