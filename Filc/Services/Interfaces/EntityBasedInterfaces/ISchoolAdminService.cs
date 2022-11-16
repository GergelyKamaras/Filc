using EFDataAccessLibrary.Models;

namespace Filc.Services.New_intefaces
{
    public interface ISchoolAdminService
    {
        public void AddSchoolAdmin(int schoolId, SchoolAdmin schoolAdmin);
    }
}
