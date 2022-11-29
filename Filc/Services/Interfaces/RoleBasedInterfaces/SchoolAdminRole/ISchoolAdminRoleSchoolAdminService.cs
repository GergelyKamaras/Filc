using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.SchoolAdminRole
{
    public interface ISchoolAdminRoleSchoolAdminService
    {
        public void AddSchoolAdmin(SchoolAdmin schoolAdmin, string email);
        public List<SchoolAdmin> GetAllSchoolAdminsBySchool(int schoolId);
        public SchoolAdmin GetSchoolAdminById(int schoolAdminId);
        public void UpdateSchoolAdmin(SchoolAdmin schoolAdmin);

        public SchoolAdmin GetASchoolAdmin();

    }
}
