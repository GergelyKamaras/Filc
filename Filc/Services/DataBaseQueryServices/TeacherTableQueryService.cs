﻿using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.Teacher;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;
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
        public TeacherDTO GetTeacher(int id)
        {
            Teacher Teacher = _db.Teacher.Include(teacher => teacher.School)
                .Include(teacher => teacher.user)
                .Include(teacher => teacher.Lessons)
                .Include(teacher => teacher.Subjects)
                .First(x => x.Id == id);
            return new TeacherDTO(Teacher);
        }
        public List<TeacherDTO> GetAllTeachers()
        {
            List<Teacher> Teachers = _db.Teacher.Include(teacher => teacher.School)
                .Include(teacher => teacher.user)
                .Include(teacher => teacher.Lessons)
                .Include(teacher => teacher.Subjects)
                .ToList();
            return ModelConverter.ModelConverter.MapTeachersToTeacherViewModels(Teachers);
        }

        //todo
        public List<TeacherDTO> GetAllTeachersBySchool(int schoolId)
        {
            List<Teacher> Teachers = _db.Teacher.Where(teacher => teacher.School.Id == schoolId)
                .Include(teacher => teacher.School)
                .Include(teacher => teacher.user)
                .Include(teacher => teacher.Lessons)
                .Include(teacher => teacher.Subjects)
                .ToList();
            return ModelConverter.ModelConverter.MapTeachersToTeacherViewModels(Teachers);
        }

        public JWTAuthenticationResponse AddTeacher(Teacher teacher)
        {
            ApplicationUser user = _userService.GetUserByEmail(teacher.user.Email);
            teacher.School = _db.School.First(school => school.Id == teacher.School.Id);
            teacher.Lessons = _db.Lesson.Where(lesson => lesson.Teachers.Any(t => t.Id == teacher.Id)).ToList();
            teacher.user = user;
            _db.Teacher.Add(teacher);
            _db.SaveChanges();

            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration successful!",
                Id = teacher.Id
            };
        }

        public void UpdateTeacher(Teacher teacher)
        {
            teacher.user = _userService.GetUserByEmail(teacher.user.Email);
            teacher.School = _db.Teacher.First(t => t.Id == teacher.Id).School;
            teacher.Lessons = _db.Teacher.First(t => t.Id == teacher.Id).Lessons;
            teacher.Subjects = _db.Teacher.First(t => t.Id == teacher.Id).Subjects;
            _db.Teacher.Update(teacher);
            _db.SaveChanges();
        }

        public void RemoveTeacher(int id)
        {
            Teacher teacher = _db.Teacher.Include(t => t.user)
                .First(t => t.Id == id);
            _userService.DeleteUser(teacher.user.Id);
            _db.SaveChanges();
        }

        
    }
}
