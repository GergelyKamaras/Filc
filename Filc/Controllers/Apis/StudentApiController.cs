using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.InputDTOs;
using Filc.Models.ViewModels.Lesson;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Student;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Filc.Services.ModelConverter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [ApiController]
    [Route("api/student")]
    [Authorize(Roles = "Student")]
    [EnableCors]
    public class StudentApiController : ControllerBase
    {
        
        private readonly ILessonServiceForStudentRole _lessonService;
        private readonly IMarkServiceForStudentRole _markService;
        private readonly ISchoolServiceForStudentRole _schoolService;
        private readonly IStudentServiceForStudentRole _studentService;
        private readonly IInputDTOConverter _inputDtoConverter;
        public StudentApiController(ILessonServiceForStudentRole lessonService, IMarkServiceForStudentRole markService,
            ISchoolServiceForStudentRole schoolService, IStudentServiceForStudentRole studentService, IInputDTOConverter inputDtoConverter)
        {
            _studentService = studentService;
            _lessonService = lessonService;
            _markService = markService;
            _schoolService = schoolService;
            _inputDtoConverter = inputDtoConverter;
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
        public void UpdateStudent([FromBody] StudentInputDTO studentInputDto)
        {
            Student student = _inputDtoConverter.ConvertDtoToStudent(studentInputDto);
            _studentService.UpdateStudent(student);
        }
    }
}
