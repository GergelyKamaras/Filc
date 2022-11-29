using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Authorize]
    [ApiController]
    [Route("api/student")]
    public class StudentApiController : ControllerBase
    {
        
        private readonly ILessonServiceForStudentRole _lessonService;
        private readonly IMarkServiceForStudentRole _markService;
        private readonly ISchoolServiceForStudentRole _schoolService;
        private readonly IStudentServiceForStudentRole _studentService;
        public StudentApiController(ILessonServiceForStudentRole lessonService, IMarkServiceForStudentRole markService,
            ISchoolServiceForStudentRole schoolService, IStudentServiceForStudentRole studentService)
        {
            _studentService = studentService;
            _lessonService = lessonService;
            _markService = markService;
            _schoolService = schoolService;
        }
    }
}
