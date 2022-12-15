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

namespace Filc.Controllers.Apis
{
    
    [ApiController]
    [Route("api/schooladmins")]
    [Authorize(Roles = "SchoolAdmin")]
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
        [Route("schools/{id}/admins")]
        public List<Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO> GetAllSchoolAdminsBySchool(int schoolId)
        {
            return _schoolAdminService.GetAllSchoolAdminsBySchool(schoolId);
        }

        [HttpGet]
        [Route("{id}")]
        public Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO GetSchoolAdminById(int id)
        {
            return _schoolAdminService.GetSchoolAdminById(id);
        }

        [HttpPost]
        [Route("register/schooladmin")]
        public async Task<ObjectResult> AddSchoolAdmin([FromBody] SchoolAdmin admin)
        {
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
            return Ok(_schoolAdminService.AddSchoolAdmin(admin));
        }

        [HttpPut]
        public void UpdateSchoolAdmin(SchoolAdmin admin)
        {
            _schoolAdminService.UpdateSchoolAdmin(admin);
        }

        // Schools

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
        [Route("register/teacher")]
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
        [Route("register/parent")]
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
        [Route("parents")]
        public void DeleteParent(int id)
        {
            _parentService.DeleteParent(id);
        }
    }
}
