using EFDataAccessLibrary.Models;
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
        public School GetSchool(int id)
        {
            return _schoolService.GetSchool(id);
        }

        // Lessons
        [HttpGet]
        [Route("lessons/{id}")]
        public Lesson GetLesson(int id)
        {
            return _lessonService.GetLessonById(id);
        }

        [HttpGet]
        [Route("lessons/students/{id}")]
        public List<Lesson> GetLessonsByStudent(int id)
        {
            return _lessonService.GetLessonByStudentId(id);
        }

        // Marks
        [HttpGet]
        [Route("marks/{id}")]
        public Mark GetMark(int id)
        {
            return _markService.GetMark(id);
        }

        [HttpGet]
        [Route("marks/student/{id}")]
        public List<Mark> GetMarksByStudent(int id)
        {
            return _markService.GetMarksByStudent(id);
        }

        // Students
        [HttpGet]
        [Route("students/{id}")]
        public Student GetStudent(int id)
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
