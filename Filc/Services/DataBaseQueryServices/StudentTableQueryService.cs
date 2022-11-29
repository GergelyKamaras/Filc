using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
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
        public Student GetStudent(int id)
        {
            return _db.Student.Include(student => student.user)
                .Include(student => student.Lessons)
                .Include(student => student.School)
                .First(x => x.Id == id);
        }

        public List<Student> GetAllStudents()
        {
            return _db.Student.Include(student => student.user)
                .Include(student => student.Lessons)
                .Include(student => student.School)
                .ToList();
        }

        public void AddStudent(Student student)
        {
            IdentityUser user = _userService.GetUserByEmail(student.user.Email);
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
