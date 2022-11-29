using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class TeacherTableQueryService : ITeacherServiceFullAccess
    {
        private ESContext _db;
        private IUserServiceFullAccess _userService;
        public TeacherTableQueryService(ESContext esContext, IUserServiceFullAccess userService)
        {
            _db = esContext;
            _userService = userService;
        }
        public Teacher GetTeacher(int id)
        {
            return _db.Teacher.Include(teacher => teacher.School)
                .Include(teacher => teacher.user)
                .Include(teacher => teacher.Lessons)
                .Include(teacher => teacher.Subjects)
                .First(x => x.Id == id);
        }
        public List<Teacher> GetAllTeachers()
        {
            return _db.Teacher.Include(teacher => teacher.School)
                .Include(teacher => teacher.user)
                .Include(teacher => teacher.Lessons)
                .Include(teacher => teacher.Subjects)
                .ToList();
        }
        public List<Teacher> GetAllTeachersBySchool(int schoolId)
        {
            return _db.Teacher.Where(teacher => teacher.School.Id == schoolId)
                .Include(teacher => teacher.School)
                .Include(teacher => teacher.user)
                .Include(teacher => teacher.Lessons)
                .Include(teacher => teacher.Subjects)
                .ToList();
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
