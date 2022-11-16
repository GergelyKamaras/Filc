using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.UserControllers
{
    public class SchoolAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
