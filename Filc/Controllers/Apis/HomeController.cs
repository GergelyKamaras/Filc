using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Route("/api/hello")]
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello, I am Filc!";
        }
    }
}
