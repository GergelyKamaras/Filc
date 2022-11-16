using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GovernmentAdminApi : Controller
    {
        private readonly IGovernmentAdminService _governmentAdminService;
        private readonly ILessonService _lessonService;
        private readonly IMarkService _markService;
        private readonly IParentService _parentService;
        private readonly ISchoolAdminService _schoolAdminService;
        private readonly ISchoolService _schoolService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public GovernmentAdminApi(IGovernmentAdminService governmentAdminService, ILessonService lessonService, 
            IMarkService markService, IParentService parentService, ISchoolAdminService schoolAdminService, 
            ISchoolService schoolService, IStudentService studentService, ITeacherService teacherService)
        {
            _governmentAdminService = governmentAdminService;
            _lessonService = lessonService;
            _markService = markService;
            _parentService = parentService;
            _schoolAdminService = schoolAdminService;
            _schoolService = schoolService;
            _studentService = studentService;
            _teacherService = teacherService;
        }
        
        [HttpGet]
        [Route("school")]
        public School GetSchool(int schoolId)
        {
            return null;
        }

        [HttpPost]
        [Route("school")]
        public void AddSchool(School school)
        {
        }

        [HttpPut]
        [Route("school")]
        public void UpdateSchool(School school)
        {
        }

        [HttpDelete]
        [Route("school")]
        public void DeleteSchool(int schoolId)
        {
        }
    }
}
