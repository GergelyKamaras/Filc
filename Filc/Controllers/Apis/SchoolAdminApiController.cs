using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Filc.Services.Interfaces.RoleBasedInterfaces.SchoolAdminRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Filc.Controllers.Apis
{
    
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
        //test
        [HttpGet]
        public SchoolAdmin GetASchoolAdmin()
        {
            return _schoolAdminService.GetASchoolAdmin();
        }

        [HttpGet]
        [Route("schools/{id}/admins")]
        public List<SchoolAdmin> GetAllSchoolAdminsBySchool(int schoolId)
        {
            return _schoolAdminService.GetAllSchoolAdminsBySchool(schoolId);
        }

        [HttpGet]
        [Route("{id}")]
        public SchoolAdmin GetSchoolAdminById(int id)
        {
            return _schoolAdminService.GetSchoolAdminById(id);
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
