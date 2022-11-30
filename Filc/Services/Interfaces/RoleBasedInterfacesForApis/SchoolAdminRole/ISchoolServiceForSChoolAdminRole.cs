using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole
{
    public interface ISchoolServiceForSchoolAdminRole
    {
        public SchoolViewModel GetSchool(int id);

        public void UpdateSchool(School school);
    }
}
