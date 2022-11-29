using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ISchoolAdminServiceFullAccess : ISchoolAdminServiceForSchoolAdminRole
    {
        public List<SchoolAdmin> GetAllSchoolAdmins();
        public void DeleteSchoolAdmin(int schoolAdminId);
    }
}
