using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.ModelInterfaces;
using Filc.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Filc.Services.Interfaces.RoleBasedInterfaces.SchoolAdminRole;

namespace Filc.Controllers.Apis
{
    
    
    [Route("api/schooladmin")]
    [ApiController]
    public class SchoolAdminApi : ControllerBase
    {
        private ILessonService _lessonService;
        private IMarkService _markService;
        private IParentService _parentService;
        private ISchoolAdminRoleSchoolAdminService _schoolAdminService;
        private ISchoolService _schoolService;
        private IStudentService _studentService;
        private ITeacherService _teacherService;

        public SchoolAdminApi(ILessonService lessonService, IMarkService markService, IParentService parentService, 
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

        

        // Lessons
        [HttpGet]
        [Route("lesson")]
        public Lesson GetLesson(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("lesson")]
        public void AddLesson([FromBody]Lesson lesson)
        {
        }

        [HttpPut]
        [Route("lesson")]
        public void UpdateLesson([FromBody]Lesson lesson)
        {
        }

        [HttpDelete]
        [Route("lesson")]
        public void DeleteLesson(int id)
        {
        }

        //Marks
        [HttpGet]
        [Route("mark")]
        public Mark GetMark(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("mark")]
        public void AddMark([FromBody]Mark mark)
        {
        }

        [HttpPut]
        [Route("mark")]
        public void UpdateMark([FromBody]Mark mark)
        {
        }

        [HttpDelete]
        [Route("mark")]
        public void DeleteMark(int id)
        {
        }
    }
}
