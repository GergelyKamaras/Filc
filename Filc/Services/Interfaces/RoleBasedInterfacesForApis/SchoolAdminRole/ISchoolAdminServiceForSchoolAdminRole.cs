using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.SchoolAdminRole
{
    public interface ISchoolAdminServiceForSchoolAdminRole
    {
        public void AddSchoolAdmin(SchoolAdmin schoolAdmin, string email);
        public SchoolAdmin GetSchoolAdmin(int schoolAdminId);
        public List<SchoolAdmin> GetAllSchoolAdminsBySchool(int schoolId);
        public void UpdateSchoolAdmin(SchoolAdmin schoolAdmin);
    }
}
