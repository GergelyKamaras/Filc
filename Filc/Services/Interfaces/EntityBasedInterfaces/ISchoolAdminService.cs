using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.SchoolAdminRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ISchoolAdminService : ISchoolAdminRoleSchoolAdminService
    {
        public void AddSchoolAdmin(SchoolAdmin schoolAdmin, string email);
        public SchoolAdmin GetSchoolAdmin(int schoolAdminId);
        public void UpdateSchoolAdmin(SchoolAdmin schoolAdmin);
        public void DeleteSchoolAdmin(int schoolAdminId);
    }
}
