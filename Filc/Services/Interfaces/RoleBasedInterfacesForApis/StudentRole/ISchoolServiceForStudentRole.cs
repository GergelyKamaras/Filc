﻿using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface ISchoolServiceForStudentRole
    {
        public SchoolDTO GetSchool(int id);
    }
}
