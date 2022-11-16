using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        
        private IStudentRoleLessonService _lessonService;
        private IStudentRoleMarkService _markService;
        private IStudentRoleSchoolService _schoolService;
        private IStudentRoleStudentService _studentService;
        public StudentApiController(IStudentRoleLessonService lessonService, IStudentRoleMarkService markService,
            IStudentRoleSchoolService schoolService, IStudentRoleStudentService studentService)
        {
            _studentService = studentService;
            _lessonService = lessonService;
            _markService = markService;
            _schoolService = schoolService;
        }
    }
}
