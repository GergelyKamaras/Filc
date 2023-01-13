using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.JWTAuthenticationModel;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole
{
    public interface ISchoolServiceForSchoolAdminRole
    {
        public SchoolDTO GetSchool(int id);
        public School GetSchoolObject(int id);
        public JWTAuthenticationResponse UpdateSchool(School school);
        public List<SchoolDTO> GetAllSchools();

    }
}
