﻿using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface IStudentServiceFullAccess : IStudentServiceForParentRole, IStudentServiceForStudentRole, IStudentServiceForTeacherRole
    {
        public new Student GetStudent(int id);
        public new void UpdateStudent(Student student);
        public List<Student> GetAllStudents();
        public void AddStudent(Student student);
        public void DeleteStudent(int id);
    }
}