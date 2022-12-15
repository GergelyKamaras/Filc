using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.EntityViewModels.SchoolAdmin;
using Filc.Models.JWTAuthenticationModel;
using Filc.Models.ViewModels.Lesson;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Parent;
using Filc.Models.ViewModels.Student;
using Filc.Models.ViewModels.Teacher;
using Filc.Services;
using Filc.Services.Interfaces;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using NuGet.DependencyResolver;
using Serilog;

namespace Filc.Controllers.Apis
{
    [ApiController]
    [Route("api/governmentadmins")]
    [Authorize(Roles = "Government")]
    [EnableCors]
    public class GovernmentAdminApiController : Controller
    {
        private readonly IGovernmentAdminServiceFullAccess _governmentAdminService;
        private readonly ILessonServiceFullAccess _lessonService;
        private readonly IMarkServiceFullAccess _markService;
        private readonly IParentServiceFullAccess _parentService;
        private readonly ISchoolAdminServiceFullAccess _schoolAdminService;
        private readonly ISchoolServiceFullAccess _schoolService;
        private readonly IStudentServiceFullAccess _studentService;
        private readonly ITeacherServiceFullAccess _teacherService;
        private readonly IRegistration _registration;
        
        public GovernmentAdminApiController(IGovernmentAdminServiceFullAccess governmentAdminService, ILessonServiceFullAccess lessonService,
            IMarkServiceFullAccess markService, IParentServiceFullAccess parentService, ISchoolAdminServiceFullAccess schoolAdminService,
            ISchoolServiceFullAccess schoolService, IStudentServiceFullAccess studentService, ITeacherServiceFullAccess teacherService,
            IRegistration registration)
        {
            _governmentAdminService = governmentAdminService;
            _lessonService = lessonService;
            _markService = markService;
            _parentService = parentService;
            _schoolAdminService = schoolAdminService;
            _schoolService = schoolService;
            _studentService = studentService;
            _teacherService = teacherService;
            _registration = registration;
        }

        // Government Admins
        [HttpGet]
        public List<GovernmentAdmin> GetAllGovernmentAdmins()
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, "Get all admins");
                return _governmentAdminService.GetAllGovernmentAdmins();
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public GovernmentAdmin GetGovernmentAdmin(int id)
        {
            return _governmentAdminService.GetGovernmentAdmin(id);
        }

        [HttpPost]
        public async Task<ObjectResult> AddGovernmentAdmin([FromBody] GovernmentAdmin admin)
        {
            try
            {
                if (await _registration.Register(new RegistrationModel(admin.user, "Government")) != true)
                {
                    throw new Exception("Error registering user!");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new JWTAuthenticationResponse { Status = "Error", Message = $"{e}" });
            }
            return Ok(_governmentAdminService.AddGovernmentAdmin(admin));
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
        public List<Models.EntityViewModels.School.SchoolDTO> GetAllSchools()
        {
            return _schoolService.GetAllSchools();
        }

        [HttpGet]
        [Route("schools/{id}")]
        public Models.EntityViewModels.School.SchoolDTO GetSchool(int id)
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
        public ObjectResult AddSchool([FromBody] School school)
        {
            return Ok(_schoolService.AddSchool(school));
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
        public List<TeacherDTO> GetAllTeachers()
        {
            return _teacherService.GetAllTeachers();
        }

        [HttpGet]
        [Route("teachers/{id}")]
        public TeacherDTO GetTeacher(int id)
        {
            return _teacherService.GetTeacher(id);
        }

        [HttpGet]
        [Route("teachers/school/{id}")]
        public List<TeacherDTO> GetTeachersBySchool(int id)
        {
            return _teacherService.GetAllTeachersBySchool(id);
        }

        [HttpPost]
        [Route("teachers")]
        public async Task<ObjectResult> AddTeacher([FromBody] Teacher teacher)
        {
            try
            {
                if (await _registration.Register(new RegistrationModel(teacher.user, "Teacher")) != true)
                {
                    throw new Exception("Error registering user!");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = $"{e}" });
            }
            
            return Ok(_teacherService.AddTeacher(teacher));
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

        [HttpGet]
        [Route("lessons/teachers/{id}")]
        public List<LessonDTO> GetLessonsByTeacher(int id)
        {
            return _lessonService.GetLessonsByTeacher(id);
        }

        [HttpPost]
        [Route("lessons")]
        public ObjectResult AddLesson([FromBody] Lesson lesson)
        {
            return Ok(_lessonService.AddLesson(lesson));
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

        [HttpGet]
        [Route("marks/lesson/{id}")]
        public List<MarkDTO> GetMarksByLesson(int id)
        {
            return _markService.GetMarkByLesson(id);
        }

        [HttpPost]
        [Route("marks")]
        public ObjectResult AddMark([FromBody] Mark mark)
        {
            return Ok(_markService.AddMark(mark));
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
        [Route("students")]
        public List<StudentDTO> GetAllStudents()
        {
            return _studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("students/{id}")]
        public StudentDTO GetStudent(int id)
        {
            return _studentService.GetStudent(id);
        }

        [HttpPost]
        [Route("register/student")]
        public async Task<ObjectResult> AddStudent([FromBody] Student student)
        {
            try
            {
                if (await _registration.Register(new RegistrationModel(student.user, "Student")) != true)
                {
                    throw new Exception("Error registering user!");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = $"{e}" });
            }
            return Ok(_studentService.AddStudent(student));
        }

        [HttpPut]
        [Route("students")]
        public void UpdateStudent([FromBody] Student student)
        {
            _studentService.UpdateStudent(student);
        }

        [HttpDelete]
        [Route("students/{id}")]
        public void RemoveStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }

        // Parents
        [HttpGet]
        [Route("parents/{id}")]
        public ParentDTO GetParent(int id)
        {
            return _parentService.GetParent(id);
        }

        [HttpPost]
        [Route("parents")]
        public async Task<ObjectResult> AddParent([FromBody] Parent parent)
        {
            try
            {
                if (await _registration.Register(new RegistrationModel(parent.user, "Parent")) != true)
                {
                    throw new Exception("Error registering user!");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = $"{e}" });
            }
            return Ok(_parentService.AddParent(parent));
        }

        [HttpPut]
        [Route("parents")]
        public void UpdateParent([FromBody] Parent parent)
        {
            _parentService.UpdateParent(parent);
        }

        [HttpDelete]
        [Route("parents/{id}")]
        public void DeleteParent(int id)
        {
            _parentService.DeleteParent(id);
        }

        // SchoolAdmins
        [HttpGet]
        [Route("schooladmins")]
        public List<Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO> GetAllSchoolAdmins()
        {
            return _schoolAdminService.GetAllSchoolAdmins();
        }

        [HttpGet]
        [Route("schooladmins/school/{id}")]
        public List<Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO> GetAllSchoolAdminsBySchool(int id)
        {
            return _schoolAdminService.GetAllSchoolAdminsBySchool(id);
        }

        [HttpGet]
        [Route("schooladmins/{id}")]
        public Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO GetAdmin(int id)
        {
            return _schoolAdminService.GetSchoolAdminById(id);
        }

        [HttpPost]
        [Route("schooladmins")]
        public async Task<ObjectResult> AddSchoolAdmin([FromBody] SchoolAdmin schoolAdmin)
        {
            try
            {
                if (await _registration.Register(new RegistrationModel(schoolAdmin.user, "SchoolAdmin")) != true)
                {
                    throw new Exception("Error registering user!");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = $"{e}" });
            }
            return Ok(_schoolAdminService.AddSchoolAdmin(schoolAdmin));
        }

        [HttpPut]
        [Route("schooladmins")]
        public void UpdateSchoolAdmin([FromBody] SchoolAdmin schoolAdmin)
        {
            _schoolAdminService.UpdateSchoolAdmin(schoolAdmin);
        }

        [HttpDelete]
        [Route("schooladmins")]
        public void DeleteSchoolAdmin(int id)
        {
            _schoolAdminService.DeleteSchoolAdmin(id);
        }
    }
}
