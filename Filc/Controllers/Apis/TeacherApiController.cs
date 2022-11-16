using Filc.Services.Interfaces.EntityBasedInterfaces;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherApiController : ControllerBase
    {

        private readonly IMarkService _markService;
        private readonly ITeacherRoleLessonService _lessonService;
        private readonly ITeacherRoleSchoolService _schoolService;
        private readonly ITeacherRoleStudentService _studentService;
        private readonly ITeacherRoleTeacherService _teacherService;

        public TeacherApiController(IMarkService markService, ITeacherRoleLessonService teacherRoleLessonService,
            ITeacherRoleSchoolService teacherRoleSchoolService, ITeacherRoleStudentService teacherRoleStudentService,
            ITeacherRoleTeacherService teacherRoleTeacherService)
        {
            _markService = markService;
            _lessonService = teacherRoleLessonService;
            _schoolService = teacherRoleSchoolService;
            _studentService = teacherRoleStudentService;
            _teacherService = teacherRoleTeacherService;
        }
    }
}
