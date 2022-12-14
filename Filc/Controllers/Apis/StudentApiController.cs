using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.ViewModels.Lesson;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Student;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [ApiController]
    [Route("api/students")]
    [Authorize(Roles = "Student")]
    [EnableCors]
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
        public SchoolDTO GetSchool(int id)
        {
            return _schoolService.GetSchool(id);
        }

        // Lessons
        [HttpGet]
        [Route("lessons/{id}")]
        public LessonDTO GetLesson(int id)
        {
            return _lessonService.GetLessonById(id);
        }

        [HttpGet]
        [Route("lessons/students/{id}")]
        public List<LessonDTO> GetLessonsByStudent(int id)
        {
            return _lessonService.GetLessonByStudentId(id);
        }

        // Marks
        [HttpGet]
        [Route("marks/{id}")]
        public MarkDTO GetMark(int id)
        {
            return _markService.GetMark(id);
        }

        [HttpGet]
        [Route("marks/student/{id}")]
        public List<MarkDTO> GetMarksByStudent(int id)
        {
            return _markService.GetMarksByStudent(id);
        }

        // Students
        [HttpGet]
        [Route("students/{id}")]
        public StudentDTO GetStudent(int id)
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
