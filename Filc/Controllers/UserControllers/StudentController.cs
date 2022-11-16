using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.UserControllers
{
    [Route("/student")]
    public class StudentController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Grades()
        {
            return View();
        }
    }
}
