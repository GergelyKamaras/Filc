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
