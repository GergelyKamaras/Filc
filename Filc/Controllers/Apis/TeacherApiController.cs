using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherApiController : ControllerBase
    {

        private readonly IMarkServiceFullAccess _markService;
        private readonly ILessonServiceForTeacherRole _lessonService;
        private readonly ISchoolServiceForTeacherRole _schoolService;
        private readonly IStudentServiceForTeacherRole _studentService;
        private readonly ITeacherServiceForTeacherRole _teacherService;

        public TeacherApiController(IMarkServiceFullAccess markService, ILessonServiceForTeacherRole teacherRoleLessonService,
            ISchoolServiceForTeacherRole teacherRoleSchoolService, IStudentServiceForTeacherRole teacherRoleStudentService,
            ITeacherServiceForTeacherRole teacherRoleTeacherService)
        {
            _markService = markService;
            _lessonService = teacherRoleLessonService;
            _schoolService = teacherRoleSchoolService;
            _studentService = teacherRoleStudentService;
            _teacherService = teacherRoleTeacherService;
        }

        // Schools
        [HttpGet]
        [Route("schools/{id}")]
        public School GetSchool(int id)
        {
            return _schoolService.GetSchool(id);
        }

        // Teachers
        [HttpGet]
        [Route("{id}")]
        public Teacher GetTeacher(int id)
        {
            return _teacherService.GetTeacher(id);
        }

        [HttpPut]
        public void UpdateTeacher([FromBody] Teacher teacher)
        {
            _teacherService.UpdateTeacher(teacher);
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

        [HttpGet]
        [Route("lessons/teachers/{id}")]
        public List<Lesson> GetLessonsByTeacher(int id)
        {
            return _lessonService.GetLessonsByTeacher(id);
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

        [HttpGet]
        [Route("marks/lesson/{id}")]
        public List<Mark> GetMarksByLesson(int id)
        {
            return _markService.GetMarkByLesson(id);
        }

        [HttpPost]
        [Route("marks")]
        public void AddMark([FromBody] Mark mark)
        {
            _markService.AddMark(mark);
        }

        [HttpPut]
        [Route("marks")]
        public void UpdateMark([FromBody] Mark mark)
        {
            _markService.UpdateMark(mark);
        }

        [HttpDelete]
        [Route("marks/{id}")]
        public void DeleteMark(int id)
        {
            _markService.DeleteMark(id);
        }

        // Students
        [HttpGet]
        [Route("students/{id}")]
        public Student GetStudent(int id)
        {
            return _studentService.GetStudent(id);
        }
    }
}
