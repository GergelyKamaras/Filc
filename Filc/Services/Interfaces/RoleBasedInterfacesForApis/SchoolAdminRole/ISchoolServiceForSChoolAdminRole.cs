using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole
{
    public interface ISchoolServiceForSchoolAdminRole
    {
        public School GetSchool(int id);

        public void UpdateSchool(School school);
    }
}
