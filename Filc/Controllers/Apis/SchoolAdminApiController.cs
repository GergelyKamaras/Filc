using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Filc.Services.Interfaces.RoleBasedInterfaces.SchoolAdminRole;
using Microsoft.AspNetCore.Authorization;

namespace Filc.Controllers.Apis
{
    [Authorize]
    [ApiController]
    [Route("api/schooladmins")]
    public class SchoolAdminApiController : ControllerBase
    {
        private readonly ISchoolAdminRoleSchoolAdminService _schoolAdminService;
        private readonly ILessonService _lessonService;
        private readonly IMarkService _markService;
        private readonly IParentService _parentService;
        private readonly ISchoolService _schoolService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public SchoolAdminApiController(ILessonService lessonService, IMarkService markService, IParentService parentService, 
            ISchoolAdminRoleSchoolAdminService schoolAdminService, ISchoolService schoolService, 
            IStudentService studentService, ITeacherService teacherService)
        {
            _lessonService = lessonService;
            _markService = markService;
            _parentService = parentService;
            _schoolAdminService = schoolAdminService;
            _schoolService = schoolService;
            _studentService = studentService;
            _teacherService = teacherService;
        }

        [HttpGet]
        [Route("schools/{id}")]
        public List<SchoolAdmin> GetAllSchoolAdminsBySchool(int id)
        {
            return _schoolAdminService.GetAllSchoolAdminsBySchool(id);
        }

        [HttpPost]
        public void AddSchoolAdmin([FromBody] SchoolAdmin admin)
        {
            _schoolAdminService.AddSchoolAdmin(admin, admin.user.Email);
        }

        [HttpPut]
        public void UpdateSchoolAdmin(SchoolAdmin admin)
        {
            _schoolAdminService.UpdateSchoolAdmin(admin);
        }
    }
}
