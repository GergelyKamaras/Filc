using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.SchoolAdmin;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ISchoolAdminServiceFullAccess : ISchoolAdminServiceForSchoolAdminRole
    {
        public List<SchoolAdminDTO> GetAllSchoolAdmins();
        public void DeleteSchoolAdmin(int schoolAdminId);
    }
}
