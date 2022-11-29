using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Authorize]
    [ApiController]
    [Route("api/teacher")]
    public class TeacherApiController : ControllerBase
    {

        private readonly IMarkServiceFullAccess _markService;
        private readonly ILessonServiceForTeacherRole _lessonService;
        private readonly ISchoolServiceForTeacherRole _schoolService;
        private readonly IStudentServiceForTeacherRole _studentService;
        private readonly ITeacherServiceForTeacherRole _teacherService;

        public TeacherApiController(IMarkServiceFullAccess markService, ILessonServiceForTeacherRole teacherRoleLessonService,
            ISchoolServiceForTeacherRole teacherRoleSchoolService, IStudentServiceForTeacherRole teacherRoleStudentService,
            ITeacherServiceForTeacherRole teacherRoleTeacherService)
        {
            _markService = markService;
            _lessonService = teacherRoleLessonService;
            _schoolService = teacherRoleSchoolService;
            _studentService = teacherRoleStudentService;
            _teacherService = teacherRoleTeacherService;
        }
    }
}
