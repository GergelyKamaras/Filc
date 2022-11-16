using Filc.Services.Interfaces.EntityBasedInterfaces;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherApiController : ControllerBase
    {

        private IMarkService _markService;
        private ITeacherRoleLessonService _lessonService;
        private ITeacherRoleSchoolService _schoolService;
        private ITeacherRoleStudentService _studentService;
        private ITeacherRoleTeacherService _teacherService;

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
