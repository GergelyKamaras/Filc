using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.SchoolAdminRole
{
    public interface ISchoolAdminRoleSchoolAdminService
    {
        public SchoolAdmin GetSchoolAdmin(int schoolAdminId);
        public void UpdateSchoolAdmin(SchoolAdmin schoolAdmin);
    }
}
