using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole;
using Microsoft.AspNetCore.Authorization;
using Filc.Models.ViewModels.Lesson;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Parent;
using Filc.Models.ViewModels.Student;
using Filc.Models.ViewModels.Teacher;
using Microsoft.AspNetCore.Cors;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces;
using Filc.ViewModel;
using Filc.Services;

namespace Filc.Controllers.Apis
{
    
    [ApiController]
    [Route("api/schooladmins")]
    //Authorize(Roles = "SchoolAdmin")]
    [EnableCors]
    public class SchoolAdminApiController : ControllerBase
    {
        private readonly ISchoolAdminServiceForSchoolAdminRole _schoolAdminService;
        private readonly ILessonServiceFullAccess _lessonService;
        private readonly IMarkServiceFullAccess _markService;
        private readonly IParentServiceFullAccess _parentService;
        private readonly ISchoolServiceForSchoolAdminRole _schoolService;
        private readonly IStudentServiceFullAccess _studentService;
        private readonly ITeacherServiceFullAccess _teacherService;
        private readonly IRegistration _registration;

        public SchoolAdminApiController(ILessonServiceFullAccess lessonService, IMarkServiceFullAccess markService, IParentServiceFullAccess parentService, 
            ISchoolAdminServiceForSchoolAdminRole schoolAdminService, ISchoolServiceForSchoolAdminRole schoolService, 
            IStudentServiceFullAccess studentService, ITeacherServiceFullAccess teacherService,
            IRegistration registration)
        {
            _lessonService = lessonService;
            _markService = markService;
            _parentService = parentService;
            _schoolAdminService = schoolAdminService;
            _schoolService = schoolService;
            _studentService = studentService;
            _teacherService = teacherService;
            _registration = registration;
        }
        
        // SchoolAdmins
        [HttpGet]
        [Route("schools/{schoolId}/admins")]
        public List<Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO> GetAllSchoolAdminsBySchool(int schoolId)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get schooladmins by school {schoolId}");
            return _schoolAdminService.GetAllSchoolAdminsBySchool(schoolId);
        }

        [HttpGet]
        [Route("{id}")]
        public Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO GetSchoolAdminById(int id)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Get school admin {id}");
            return _schoolAdminService.GetSchoolAdminById(id);
        }

        [HttpPost]
        [Route("register/schooladmin")]
        public async Task<ObjectResult> AddSchoolAdmin([FromBody] SchoolAdmin admin)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            try
            {
                if (await _registration.Register(new RegistrationModel(admin.user, "SchoolAdmin")) != true)
                {
                    throw new Exception("Error registering user!");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new JWTAuthenticationResponse { Status = "Error", Message = $"{e}" });
            }
            CustomLogger.LogRequest(token, $"Add school admin");
            return Ok(_schoolAdminService.AddSchoolAdmin(admin));
        }

        [HttpPut]
        public void UpdateSchoolAdmin(SchoolAdmin admin)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Update school admin {admin.Id}");
            _schoolAdminService.UpdateSchoolAdmin(admin);
        }

        // Schools
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
        public ObjectResult AddLesson([FromBody] Lesson lesson)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            CustomLogger.LogRequest(token, $"Add lesson");
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
        public ObjectResult AddMark([FromBody] Mark mark)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
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
        public async Task<ObjectResult> AddStudent([FromBody] Student student)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
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
        public async Task<ObjectResult> AddParent([FromBody] Parent parent)
        {
            string token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
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
    }
}
