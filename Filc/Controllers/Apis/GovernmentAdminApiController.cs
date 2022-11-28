using System.Diagnostics.Contracts;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [ApiController]
    [Route("api/governmentadmins")]
    public class GovernmentAdminApiController : Controller
    {
        private readonly IGovernmentAdminService _governmentAdminService;
        private readonly ILessonService _lessonService;
        private readonly IMarkService _markService;
        private readonly IParentService _parentService;
        private readonly ISchoolAdminService _schoolAdminService;
        private readonly ISchoolService _schoolService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        
        public GovernmentAdminApiController(IGovernmentAdminService governmentAdminService, ILessonService lessonService,
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

        // Government Admins
        [HttpGet]
        public List<GovernmentAdmin> GetAllGovernmentAdmins()
        {
            return _governmentAdminService.GetAllGovernmentAdmins();
        }

        [HttpGet]
        [Route("{id}")]
        public GovernmentAdmin GetGovernmentAdmin(int id)
        {
            return _governmentAdminService.GetGovernmentAdmin(id);
        }

        [HttpPost]
        public void AddGovernmentAdmin([FromBody] GovernmentAdmin admin)
        {
            _governmentAdminService.AddGovernmentAdmin(admin, admin.user.Email);
        }

        [HttpPut]
        public void UpdateGovernmentAdmin([FromBody] GovernmentAdmin admin)
        {
            _governmentAdminService.UpdateGovernmentAdmin(admin);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public void DeleteGovernmentAdmin(int id)
        {
            _governmentAdminService.RemoveGovernmentAdmin(id);
        }

        // Schools
        [HttpGet]
        [Route("schools")]
        public List<School> GetAllSchools()
        {
            return _schoolService.GetAllSchools();
        }

        [HttpGet]
        [Route("schools/{id}")]
        public School GetSchool(int id)
        {
            return _schoolService.GetSchool(id);
        }

        [HttpPut]
        [Route("schools")]
        public void UpdateSchool([FromBody] School school)
        {
            _schoolService.UpdateSchool(school);
        }

        [HttpPost]
        [Route("schools")]
        public void AddSchool([FromBody] School school)
        {
            _schoolService.AddSchool(school);
        }

        [HttpDelete]
        [Route("schools/{id}")]
        public void DeleteSchool(int id)
        {
            _schoolService.RemoveSchool(id);
        }

        // Teachers
        [HttpGet]
        [Route("teachers")]
        public List<Teacher> GetAllTeachers()
        {
            return _teacherService.GetAllTeachers();
        }

        [HttpGet]
        [Route("teachers/{id}")]
        public Teacher GetTeacher(int id)
        {
            return _teacherService.GetTeacher(id);
        }

        [HttpGet]
        [Route("teachers/school/{id}")]
        public List<Teacher> GetTeachersBySchool(int id)
        {
            return _teacherService.GetAllTeachersBySchool(id);
        }

        [HttpPost]
        [Route("teachers")]
        public void AddTeacher([FromBody] Teacher teacher)
        {
            _teacherService.AddTeacher(teacher, teacher.user.Email);
        }

        [HttpPut]
        [Route("teachers")]
        public void UpdateTeacher([FromBody] Teacher teacher)
        {
            _teacherService.UpdateTeacher(teacher);
        }

        [HttpDelete]
        [Route("teachers/{id}")]
        public void DeleteTeacher(int id)
        {
            _teacherService.RemoveTeacher(id);
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

        [HttpPost]
        [Route("lessons")]
        public void AddLesson([FromBody] Lesson lesson)
        {
            _lessonService.AddLesson(lesson);
        }

        [HttpPut]
        [Route("lessons")]
        public void UpdateLesson([FromBody] Lesson lesson)
        {
            _lessonService.UpdateLesson(lesson);
        }

        [HttpDelete]
        [Route("lessons/{id}")]
        public void DeleteLesson(int id)
        {
            _lessonService.DeleteLesson(id);
        }

    }
}
