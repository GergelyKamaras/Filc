using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
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
        public StudentViewModel GetStudent(int id)
        {
            Student student = _db.Student.Include(student => student.user)
                .Include(student => student.Lessons)
                .Include(student => student.School)
                .Include(student => student.Marks)
                .First(x => x.Id == id);
            return new StudentViewModel(student);
        }

        public List<StudentViewModel> GetAllStudents()
        {
            List<Student> students = _db.Student.Include(student => student.user)
                .Include(student => student.Lessons)
                .Include(student => student.School)
                .Include(student => student.Marks)
                .ToList();
            return ModelConverter.ModelConverter.MapStudentsToStudentViewModels(students);
        }

        public void AddStudent(Student student)
        {
            ApplicationUser user = _userService.GetUserByEmail(student.user.Email);
            student.user = user;
            _db.Student.Add(student);
            _db.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _db.Student.Update(student);
            _db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            _db.Student.Remove(_db.Student.First(student => student.Id == id));
            _db.SaveChanges();
        }
    }
}
