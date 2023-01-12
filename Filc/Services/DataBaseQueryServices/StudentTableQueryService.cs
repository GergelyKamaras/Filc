using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.InputDTOs;
using Filc.Models.JWTAuthenticationModel;
using Filc.Models.ViewModels.Shared;
using Filc.Models.ViewModels.Student;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class StudentTableQueryService : IStudentServiceFullAccess
    {
        private ESContext _db;
        private IUserServiceFullAccess _userService;
        public StudentTableQueryService(ESContext esContext, IUserServiceFullAccess userService)
        {
            _db = esContext;
            _userService = userService;
        }
        public StudentDTO GetStudent(int id)
        {
            Student student = _db.Student.Include(student => student.user)
                .Include(student => student.Lessons)
                .Include(student => student.School)
                .Include(student => student.Marks)
                .First(x => x.Id == id);
            return new StudentDTO(student);
        }

        public List<StudentDTO> GetStudentsbyTeacherId(int teacherId)
        {

            var teacherLessons = _db.Teacher
                                .Include(t => t.user)
                                .Include(t => t.Lessons)
                                .Include(t => t.Subjects)
                                .Where(t => t.Id == teacherId)
                                .SelectMany(t => t.Lessons ?? Enumerable.Empty<Lesson>());

            var studentList = _db.Student
                                .Include(s => s.user)
                                .Include(s => s.Marks)
                                .Include(s => s.Lessons)
                                .Where(s => (s.Lessons ?? Enumerable.Empty<Lesson>()).Intersect(teacherLessons).Any())
                                .ToList();

            return ModelConverter.ModelConverter.MapStudentsToStudentViewModels(studentList);
        }

        public List<StudentDTO> GetAllStudents()
        {
            List<Student> students = _db.Student.Include(student => student.user)
                .Include(student => student.Lessons)
                .Include(student => student.School)
                .Include(student => student.Marks)
                .ToList();
            return ModelConverter.ModelConverter.MapStudentsToStudentViewModels(students);
        }

        public JWTAuthenticationResponse AddStudent(Student student)
        {
            _db.Student.Add(student);
            _db.SaveChanges();
            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration successful!",
                Id = student.Id
            };
        }

        public void UpdateStudent(Student student)
        {
            _db.Student.Update(student);
            _db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student student = _db.Student.Include(s => s.user)
                .First(s => s.Id == id);
            _userService.DeleteUser(student.user.Id);
            _db.SaveChanges();
        }
    }
}
