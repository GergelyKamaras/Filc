using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ISchoolAdminService
    {
        public void AddSchoolAdmin(int schoolId, SchoolAdmin schoolAdmin);
    }
}
