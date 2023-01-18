using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.EntityViewModels.SchoolAdmin;
using Filc.Models.EntityViewModels.Student;
using Filc.Models.EntityViewModels.Teacher;
using Filc.Models.InputDTOs;
using Filc.Models.JWTAuthenticationModel;
using Filc.Models.ViewModels.Lesson;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Parent;
using Filc.Models.ViewModels.Shared;
using Filc.Services;
using Filc.Services.Interfaces;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.Services.ModelConverter;
using Filc.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using NuGet.DependencyResolver;
using Serilog;

namespace Filc.Controllers.Apis
{
    [ApiController]
    [Route("api/government")]
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
        private readonly IInputDTOConverter _inputDtoConverter;
        
        public GovernmentAdminApiController(IGovernmentAdminServiceFullAccess governmentAdminService, ILessonServiceFullAccess lessonService,
            IMarkServiceFullAccess markService, IParentServiceFullAccess parentService, ISchoolAdminServiceFullAccess schoolAdminService,
            ISchoolServiceFullAccess schoolService, IStudentServiceFullAccess studentService, ITeacherServiceFullAccess teacherService,
            IRegistration registration, IInputDTOConverter inputDtoConverter)
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
            _inputDtoConverter = inputDtoConverter;
        }

        // Government Admins
        [HttpGet]
        public List<GovernmentAdmin> GetAllGovernmentAdmins()
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
        
            CustomLogger.LogRequest(token, "Get all admins");
            return _governmentAdminService.GetAllGovernmentAdmins();
        }

        [HttpGet]
        [Route("{id}")]
        public GovernmentAdmin GetGovernmentAdmin(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];

            CustomLogger.LogRequest(token, $"Get admin {id}");
            return _governmentAdminService.GetGovernmentAdmin(id);
        }

        [HttpPost]
        public async Task<ObjectResult> AddGovernmentAdmin([FromBody] GovernmentAdminInputDTO adminInputDto)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            GovernmentAdmin admin = _inputDtoConverter.ConvertDtoToGovernmentAdmin(adminInputDto);
            if (await _registration.Register(new RegistrationModel(admin.user, "Government")) != true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = "Error registering user!" });
            }
            
            CustomLogger.LogRequest(token, "Add Government admin");
            return Ok(_governmentAdminService.AddGovernmentAdmin(admin));
        }

        [HttpPut]
        public void UpdateGovernmentAdmin([FromBody] GovernmentAdmin admin)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Update government admin {admin.Id}");
            _governmentAdminService.UpdateGovernmentAdmin(admin);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public void DeleteGovernmentAdmin(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Delete government admin {id}");
            _governmentAdminService.RemoveGovernmentAdmin(id);
        }

        // Schools
        [HttpGet]
        [Route("schools")]
        public List<Models.EntityViewModels.School.SchoolDTO> GetAllSchools()
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, "Get all schools");
            return _schoolService.GetAllSchools();
        }

        [HttpGet]
        [Route("schools/{id}")]
        public Models.EntityViewModels.School.SchoolDTO GetSchool(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get school {id}");
            return _schoolService.GetSchool(id);
        }

        [HttpPut]
        [Route("schools")]
        public void UpdateSchool([FromBody] School school)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Update school {school.Id}");
            _schoolService.UpdateSchool(school);
        }

        [HttpPost]
        [Route("schools")]
        public ObjectResult AddSchool([FromBody] SchoolInputDTO schoolInputDto)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            School school = _inputDtoConverter.ConvertDtoToSchool(schoolInputDto);
            CustomLogger.LogRequest(token, $"Add school");
            return Ok(_schoolService.AddSchool(school));
        }

        [HttpDelete]
        [Route("schools/{id}")]
        public void DeleteSchool(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Delete school {id}");
            _schoolService.RemoveSchool(id);
        }

        // Teachers
        [HttpGet]
        [Route("teachers")]
        public List<TeacherDTO> GetAllTeachers()
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get all teachers");
            return _teacherService.GetAllTeachers();
        }

        [HttpGet]
        [Route("teachers/{id}")]
        public TeacherDTO GetTeacher(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get teacher {id}");
            return _teacherService.GetTeacher(id);
        }

        [HttpGet]
        [Route("teachers/school/{id}")]
        public List<TeacherDTO> GetTeachersBySchool(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get teachers by school {id}");
            return _teacherService.GetAllTeachersBySchool(id);
        }

        [HttpPost]
        [Route("register/teacher")]
        public async Task<ObjectResult> AddTeacher([FromBody] TeacherInputDTO teacherInputDto)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            Teacher teacher = _inputDtoConverter.ConvertDtoToTeacher(teacherInputDto);
            
            if (await _registration.Register(new RegistrationModel(teacher.user, "Teacher")) != true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = "Error registering user!" });
            }
            
            CustomLogger.LogRequest(token, $"Add teacher");
            return Ok(_teacherService.AddTeacher(teacher));
        }

        [HttpPut]
        [Route("teachers")]
        public void UpdateTeacher([FromBody] Teacher teacher)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Update teacher {teacher.Id}");
            _teacherService.UpdateTeacher(teacher);
        }

        [HttpDelete]
        [Route("teachers/{id}")]
        public void DeleteTeacher(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Delete teacher {id}");
            _teacherService.RemoveTeacher(id);
        }

        // Lessons
        [HttpGet]
        [Route("lessons/{id}")]
        public LessonDTO GetLesson(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get Lesson {id}");
            return _lessonService.GetLessonById(id);
        }

        [HttpGet]
        [Route("lessons/students/{id}")]
        public List<LessonDTO> GetLessonsByStudent(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get lessons by student {id}");
            return _lessonService.GetLessonByStudentId(id);
        }

        [HttpGet]
        [Route("lessons/teachers/{id}")]
        public List<LessonDTO> GetLessonsByTeacher(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get lessons by teacher {id}");
            return _lessonService.GetLessonsByTeacher(id);
        }

        [HttpPost]
        [Route("lessons")]
        public ObjectResult AddLesson([FromBody] LessonInputDTO lessonInputDto)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Add lesson");
            var lesson = _inputDtoConverter.ConvertDtoToLesson(lessonInputDto);
            return Ok(_lessonService.AddLesson(lesson));
        }

        [HttpPut]
        [Route("lessons")]
        public void UpdateLesson([FromBody] Lesson lesson)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Update lesson {lesson.Id}");
            _lessonService.UpdateLesson(lesson);
        }

        [HttpDelete]
        [Route("lessons/{id}")]
        public void DeleteLesson(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Delete lesson {id}");
            _lessonService.DeleteLesson(id);
        }

        // Marks
        [HttpGet]
        [Route("marks/{id}")]
        public MarkDTO GetMark(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get mark {id}");
            return _markService.GetMark(id);
        }

        [HttpGet]
        [Route("marks/student/{id}")]
        public List<MarkDTO> GetMarksByStudent(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get marks by student {id}");
            return _markService.GetMarksByStudent(id);
        }

        [HttpGet]
        [Route("marks/lesson/{id}")]
        public List<MarkDTO> GetMarksByLesson(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get marks by lesson {id}");
            return _markService.GetMarkByLesson(id);
        }

        [HttpPost]
        [Route("marks")]
        public ObjectResult AddMark([FromBody] MarkInputDTO markInputDto)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            var mark = _inputDtoConverter.ConvertDtoToMark(markInputDto);
            CustomLogger.LogRequest(token, $"Add mark");
            return Ok(_markService.AddMark(mark));
        }

        [HttpPut]
        [Route("marks")]
        public void UpdateMark([FromBody] Mark mark)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Update mark {mark.Id}");
            _markService.UpdateMark(mark);
        }

        [HttpDelete]
        [Route("marks/{id}")]
        public void DeleteMark(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Delete mark {id}");
            _markService.DeleteMark(id);
        }

        // Students
        [HttpGet]
        [Route("students")]
        public List<StudentDTO> GetAllStudents()
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get all students");
            return _studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("students/{id}")]
        public StudentDTO GetStudent(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get student {id}");
            return _studentService.GetStudent(id);
        }

        [HttpPost]
        [Route("register/student")]
        public async Task<ObjectResult> AddStudent([FromBody] StudentInputDTO studentInputDto)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            Student student = _inputDtoConverter.ConvertDtoToStudent(studentInputDto);
            if (await _registration.Register(new RegistrationModel(student.user, "Student")) != true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = "Error registering user!" });
            }
            
            CustomLogger.LogRequest(token, "Add student");
            return Ok(_studentService.AddStudent(student));
        }

        [HttpPut]
        [Route("students")]
        public void UpdateStudent([FromBody] Student student)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Update student {student.Id}");
            _studentService.UpdateStudent(student);
        }

        [HttpDelete]
        [Route("students/{id}")]
        public void RemoveStudent(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Delete student {id}");
            _studentService.DeleteStudent(id);
        }

        // Parents
        [HttpGet]
        [Route("parents/{id}")]
        public ParentDTO GetParent(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1]; 
            CustomLogger.LogRequest(token, $"Get parent {id}");
            return _parentService.GetParent(id);
        }

        [HttpPost]
        [Route("register/parent")]
        public async Task<ObjectResult> AddParent([FromBody] ParentInputDTO parentInputDto)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            Parent parent = _inputDtoConverter.ConvertDtoToParent(parentInputDto);
            
            if (await _registration.Register(new RegistrationModel(parent.user, "Parent")) != true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = "Error registering user!" });
            }
            
            CustomLogger.LogRequest(token, $"Add parent");
            return Ok(_parentService.AddParent(parent));
        }

        [HttpPut]
        [Route("parents")]
        public void UpdateParent([FromBody] Parent parent)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Update parent {parent.Id}");
            _parentService.UpdateParent(parent);
        }

        [HttpDelete]
        [Route("parents/{id}")]
        public void DeleteParent(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Delete parent {id}");
            _parentService.DeleteParent(id);
        }

        // SchoolAdmins
        [HttpGet]
        [Route("schooladmins")]
        public List<SchoolAdminDTO> GetAllSchoolAdmins()
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get schooladmins");
            return _schoolAdminService.GetAllSchoolAdmins();
        }

        [HttpGet]
        [Route("schooladmins/school/{id}")]
        public List<SchoolAdminDTO> GetAllSchoolAdminsBySchool(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get schooladmins by school {id}");
            return _schoolAdminService.GetAllSchoolAdminsBySchool(id);
        }

        [HttpGet]
        [Route("schooladmins/{id}")]
        public SchoolAdminDTO GetAdmin(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get school admin {id}");
            return _schoolAdminService.GetSchoolAdminById(id);
        }

        [HttpPost]
        [Route("schooladmins")]
        public async Task<ObjectResult> AddSchoolAdmin([FromBody] SchoolAdminInputDTO schoolAdminInputDto)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            SchoolAdmin schoolAdmin = _inputDtoConverter.ConvertDtoToSchoolAdmin(schoolAdminInputDto);
            
            if (await _registration.Register(new RegistrationModel(schoolAdmin.user, "SchoolAdmin")) != true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = $"Error registering user!" });
            }
            
            CustomLogger.LogRequest(token, $"Add school admin");
            return Ok(_schoolAdminService.AddSchoolAdmin(schoolAdmin));
        }

        [HttpPut]
        [Route("schooladmins")]
        public void UpdateSchoolAdmin([FromBody] SchoolAdmin schoolAdmin)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Update school admin {schoolAdmin.Id}");
            _schoolAdminService.UpdateSchoolAdmin(schoolAdmin);
        }

        [HttpDelete]
        [Route("schooladmins")]
        public void DeleteSchoolAdmin(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Delete school admin {id}");
            _schoolAdminService.DeleteSchoolAdmin(id);
            
        }
    }
}
