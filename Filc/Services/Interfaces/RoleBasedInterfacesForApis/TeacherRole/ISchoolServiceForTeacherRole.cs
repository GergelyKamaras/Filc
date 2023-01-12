﻿using Filc.Models.EntityViewModels.School;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface ISchoolServiceForTeacherRole
    {
        public SchoolDTO GetSchool(int id);
    }
}
