using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.AspNetCore.Identity;

namespace Filc.Services.DataBaseQueryServices
{
    public class TeacherService : ITeacherService
    {
        private ESContext _db;
        private IUserService _userService;
        public TeacherService(ESContext esContext, IUserService userService)
        {
            _db = esContext;
            _userService = userService;
        }
        public Teacher GetTeacher(int id)
        {
            return _db.Teacher.First(x => x.Id == id);
        }

        public void AddTeacher(Teacher teacher, string email)
        {
            IdentityUser user = _userService.GetUserByEmail(email);
            teacher.user = user;
            _db.Teacher.Add(teacher);
            _db.SaveChanges();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _db.Teacher.Update(teacher);
            _db.SaveChanges();
        }

        public void RemoveTeacher(int id)
        {
            _db.Teacher.Remove(_db.Teacher.First(teacher => teacher.Id == id));
            _db.SaveChanges();
        }
    }
}
