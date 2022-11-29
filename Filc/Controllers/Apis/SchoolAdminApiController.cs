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
        private readonly ISchoolAdminServiceForSchoolAdminRole _schoolAdminService;
        private readonly ILessonServiceFullAccess _lessonService;
        private readonly IMarkServiceFullAccess _markService;
        private readonly IParentServiceFullAccess _parentService;
        private readonly ISchoolServiceFullAccess _schoolService;
        private readonly IStudentServiceFullAccess _studentService;
        private readonly ITeacherServiceFullAccess _teacherService;

        public SchoolAdminApiController(ILessonServiceFullAccess lessonService, IMarkServiceFullAccess markService, IParentServiceFullAccess parentService, 
            ISchoolAdminServiceForSchoolAdminRole schoolAdminService, ISchoolServiceFullAccess schoolService, 
            IStudentServiceFullAccess studentService, ITeacherServiceFullAccess teacherService)
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
