using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.UserControllers
{
    [Route("/teacher")]
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/give-eval")]
        public IActionResult GiveEvaluation()
        {
            return View();
        }
    }
}
