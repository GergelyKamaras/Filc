﻿using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.SchoolAdmin;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole
{
    public interface ISchoolAdminServiceForSchoolAdminRole
    {
        public void AddSchoolAdmin(SchoolAdmin schoolAdmin);
        public List<SchoolAdminViewModel> GetAllSchoolAdminsBySchool(int schoolId);
        public SchoolAdminViewModel GetSchoolAdminById(int schoolAdminId);
        public void UpdateSchoolAdmin(SchoolAdmin schoolAdmin);
        public SchoolAdmin GetASchoolAdmin();

    }
}
