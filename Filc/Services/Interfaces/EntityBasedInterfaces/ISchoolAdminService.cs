using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ISchoolAdminService
    {
        public void AddSchoolAdmin(SchoolAdmin schoolAdmin);
        public SchoolAdmin GetSchoolAdmin(int schoolAdminId);
        public void UpdateSchoolAdmin(SchoolAdmin schoolAdmin);
        public void DeleteSchoolAdmin(int schoolAdminId);
    }
}
