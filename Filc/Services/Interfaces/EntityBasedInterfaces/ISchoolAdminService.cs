using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.SchoolAdminRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ISchoolAdminService : ISchoolAdminRoleSchoolAdminService
    {
        public List<SchoolAdmin> GetAllSchoolAdmins();
        public void DeleteSchoolAdmin(int schoolAdminId);
    }
}
