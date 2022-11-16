using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentApiController : ControllerBase
    {
        
        private readonly IStudentRoleLessonService _lessonService;
        private readonly IStudentRoleMarkService _markService;
        private readonly IStudentRoleSchoolService _schoolService;
        private readonly IStudentRoleStudentService _studentService;
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
