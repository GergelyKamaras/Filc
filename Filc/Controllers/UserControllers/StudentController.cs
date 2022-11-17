using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.UserControllers
{
    [Route("/nebulo")]
    public class StudentController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [Route("grades")]
        public IActionResult Grades()
        {
            return View();
        }

        [Route("timetable")]
        public IActionResult TimeTable()
        {
            return View();
        }
    }
}
