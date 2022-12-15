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
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get admin {id}");
                return _governmentAdminService.GetGovernmentAdmin(id);
                
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpPost]
        public async Task<ObjectResult> AddGovernmentAdmin([FromBody] GovernmentAdmin admin)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                if (await _registration.Register(new RegistrationModel(admin.user, "Government")) != true)
                {
                    throw new Exception("Error registering user!");
                }
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return StatusCode(StatusCodes.Status500InternalServerError,
                new JWTAuthenticationResponse { Status = "Error", Message = $"{e}" });
            }
            return Ok(_governmentAdminService.AddGovernmentAdmin(admin));
        }

        [HttpPut]
        public void UpdateGovernmentAdmin([FromBody] GovernmentAdmin admin)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Update government admin {admin.Id}");
                _governmentAdminService.UpdateGovernmentAdmin(admin);

            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
        }
        
        [HttpDelete]
        [Route("{id}")]
        public void DeleteGovernmentAdmin(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Delete government admin {id}");
                _governmentAdminService.RemoveGovernmentAdmin(id);

            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
        }

        // Schools
        [HttpGet]
        [Route("schools")]
        public List<Models.EntityViewModels.School.SchoolDTO> GetAllSchools()
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, "Get all schools");
                return _schoolService.GetAllSchools();

            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpGet]
        [Route("schools/{id}")]
        public Models.EntityViewModels.School.SchoolDTO GetSchool(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get school {id}");
                return _schoolService.GetSchool(id);

            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpPut]
        [Route("schools")]
        public void UpdateSchool([FromBody] School school)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Update school {school.Id}");
                _schoolService.UpdateSchool(school);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
        }

        [HttpPost]
        [Route("schools")]
        public ObjectResult AddSchool([FromBody] School school)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Add school");
                return Ok(_schoolService.AddSchool(school));
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpDelete]
        [Route("schools/{id}")]
        public void DeleteSchool(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Delete school {id}");
                _schoolService.RemoveSchool(id);

            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
        }

        // Teachers
        [HttpGet]
        [Route("teachers")]
        public List<TeacherDTO> GetAllTeachers()
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get all teachers");
                return _teacherService.GetAllTeachers();

            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpGet]
        [Route("teachers/{id}")]
        public TeacherDTO GetTeacher(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get teacher {id}");
                return _teacherService.GetTeacher(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpGet]
        [Route("teachers/school/{id}")]
        public List<TeacherDTO> GetTeachersBySchool(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get teachers by school {id}");
                return _teacherService.GetAllTeachersBySchool(id);

            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpPost]
        [Route("teachers")]
        public async Task<ObjectResult> AddTeacher([FromBody] Teacher teacher)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                if (await _registration.Register(new RegistrationModel(teacher.user, "Teacher")) != true)
                {
                    throw new Exception("Error registering user!");
                }
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = $"{e}" });
            }
            CustomLogger.LogRequest(token, $"Add teacher");
            return Ok(_teacherService.AddTeacher(teacher));
        }

        [HttpPut]
        [Route("teachers")]
        public void UpdateTeacher([FromBody] Teacher teacher)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Update teacher {teacher.Id}");
                _teacherService.UpdateTeacher(teacher);

            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
        }

        [HttpDelete]
        [Route("teachers/{id}")]
        public void DeleteTeacher(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Delete teacher {id}");
                _teacherService.RemoveTeacher(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
        }

        // Lessons
        [HttpGet]
        [Route("lessons/{id}")]
        public LessonDTO GetLesson(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get Lesson {id}");
                return _lessonService.GetLessonById(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpGet]
        [Route("lessons/students/{id}")]
        public List<LessonDTO> GetLessonsByStudent(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get lessons by student {id}");
                return _lessonService.GetLessonByStudentId(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpGet]
        [Route("lessons/teachers/{id}")]
        public List<LessonDTO> GetLessonsByTeacher(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get lessons by teacher {id}");
                return _lessonService.GetLessonsByTeacher(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpPost]
        [Route("lessons")]
        public ObjectResult AddLesson([FromBody] Lesson lesson)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Add lesson");
                return Ok(_lessonService.AddLesson(lesson));

            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpPut]
        [Route("lessons")]
        public void UpdateLesson([FromBody] Lesson lesson)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Update lesson {lesson.Id}");
                _lessonService.UpdateLesson(lesson);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
        }

        [HttpDelete]
        [Route("lessons/{id}")]
        public void DeleteLesson(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Delete lesson {id}");
                _lessonService.DeleteLesson(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
        }

        // Marks
        [HttpGet]
        [Route("marks/{id}")]
        public MarkDTO GetMark(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get mark {id}");
                return _markService.GetMark(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpGet]
        [Route("marks/student/{id}")]
        public List<MarkDTO> GetMarksByStudent(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get marks by student {id}");
                return _markService.GetMarksByStudent(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpGet]
        [Route("marks/lesson/{id}")]
        public List<MarkDTO> GetMarksByLesson(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Get marks by lesson {id}");
                return _markService.GetMarkByLesson(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpPost]
        [Route("marks")]
        public ObjectResult AddMark([FromBody] Mark mark)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Add mark");
                return Ok(_markService.AddMark(mark));
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
                return null;
            }
        }

        [HttpPut]
        [Route("marks")]
        public void UpdateMark([FromBody] Mark mark)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Update mark {mark.Id}");
                _markService.UpdateMark(mark);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
        }

        [HttpDelete]
        [Route("marks/{id}")]
        public void DeleteMark(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                CustomLogger.LogRequest(token, $"Delete mark {id}");
                _markService.DeleteMark(id);
            }
            catch (Exception e)
            {
                CustomLogger.LogError(token, e);
            }
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
