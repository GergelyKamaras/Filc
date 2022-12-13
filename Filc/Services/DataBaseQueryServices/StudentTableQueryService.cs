using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
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
            ApplicationUser user = _userService.GetUserByEmail(student.user.Email);
            student.School = _db.School.First(school => school.Id == student.School.Id);
            student.Marks = _db.Mark.Where(mark => mark.Student.Id == student.Id).ToList();
            student.Lessons = _db.Lesson.Where(lesson => lesson.students.Any(s => s.Id == student.Id)).ToList();
            student.user = user;
            _db.Student.Add(student);
            _db.SaveChanges();
            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration successful!"
            };
        }

        public void UpdateStudent(Student student)
        {
            student.user = _userService.GetUserByEmail(student.user.Email);
            student.School = _db.School.First(s => s.Id == student.School.Id);
            student.Marks = _db.Mark.Where(mark => mark.Student.Id == student.Id).ToList();
            student.Lessons = _db.Lesson.Where(lesson => lesson.students.Any(s => s.Id == student.Id)).ToList();
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
