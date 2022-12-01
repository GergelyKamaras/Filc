using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.ViewModels.Lesson;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Student;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [ApiController]
    [Route("api/students")]
    public class StudentApiController : ControllerBase
    {
        
        private readonly ILessonServiceForStudentRole _lessonService;
        private readonly IMarkServiceForStudentRole _markService;
        private readonly ISchoolServiceForStudentRole _schoolService;
        private readonly IStudentServiceForStudentRole _studentService;
        public StudentApiController(ILessonServiceForStudentRole lessonService, IMarkServiceForStudentRole markService,
            ISchoolServiceForStudentRole schoolService, IStudentServiceForStudentRole studentService)
        {
            _studentService = studentService;
            _lessonService = lessonService;
            _markService = markService;
            _schoolService = schoolService;
        }

        // Schools
        [HttpGet]
        [Route("schools/{id}")]
        public SchoolViewModel GetSchool(int id)
        {
            return _schoolService.GetSchool(id);
        }

        // Lessons
        [HttpGet]
        [Route("lessons/{id}")]
        public LessonViewModel GetLesson(int id)
        {
            return _lessonService.GetLessonById(id);
        }

        [HttpGet]
        [Route("lessons/students/{id}")]
        public List<LessonViewModel> GetLessonsByStudent(int id)
        {
            return _lessonService.GetLessonByStudentId(id);
        }

        // Marks
        [HttpGet]
        [Route("marks/{id}")]
        public MarkViewModel GetMark(int id)
        {
            return _markService.GetMark(id);
        }

        [HttpGet]
        [Route("marks/student/{id}")]
        public List<MarkViewModel> GetMarksByStudent(int id)
        {
            return _markService.GetMarksByStudent(id);
        }

        // Students
        [HttpGet]
        [Route("students/{id}")]
        public StudentViewModel GetStudent(int id)
        {
            return _studentService.GetStudent(id);
        }

        [HttpPut]
        [Route("students")]
        public void UpdateStudent([FromBody] Student student)
        {
            _studentService.UpdateStudent(student);
        }
    }
}
