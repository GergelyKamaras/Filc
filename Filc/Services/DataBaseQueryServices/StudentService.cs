﻿using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class StudentService : IStudentService
    {
        private ESContext _db;
        private IUserService _userService;
        public StudentService(ESContext esContext, IUserService userService)
        {
            _db = esContext;
            _userService = userService;
        }
        public Student GetStudent(int id)
        {
            return _db.Student.Include(student => student.user)
                .Include(student => student.Lessons)
                .Include(student => student.School)
                .Include(student => student.Marks)
                .First(x => x.Id == id);
        }

        public List<Student> GetAllStudents()
        {
            return _db.Student.Include(student => student.user)
                .Include(student => student.Lessons)
                .Include(student => student.School)
                .Include(student => student.Marks)
                .ToList();
        }

        public void AddStudent(Student student, string email)
        {
            IdentityUser user = _userService.GetUserByEmail(email);
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
