﻿using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Student;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface IStudentServiceForTeacherRole
    {
        public StudentDTO GetStudent(int id);
    }
}
