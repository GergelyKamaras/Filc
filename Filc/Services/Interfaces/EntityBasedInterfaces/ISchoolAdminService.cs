using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.SchoolAdminRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ISchoolAdminService : ISchoolAdminRoleSchoolAdminService
    {
        public void AddSchoolAdmin(SchoolAdmin schoolAdmin, string email);
        public void DeleteSchoolAdmin(int schoolAdminId);
    }
}
