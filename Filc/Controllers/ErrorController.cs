using Filc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [Route("/error-development")]
        public IActionResult HandleDevelopmentError([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            CustomLogger.LogError(exceptionHandlerFeature.Error.StackTrace, exceptionHandlerFeature.Error.Message);
            
            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }

        [Route("/error")]
        public IActionResult HandleProductionError()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            CustomLogger.LogError(exceptionHandlerFeature.Error.StackTrace, exceptionHandlerFeature.Error.Message);
            return Problem();
        }
    }
}
