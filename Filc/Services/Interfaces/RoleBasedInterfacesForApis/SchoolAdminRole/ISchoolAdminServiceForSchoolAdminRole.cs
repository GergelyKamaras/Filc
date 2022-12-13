using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.SchoolAdmin;
using Filc.Models.JWTAuthenticationModel;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole
{
    public interface ISchoolAdminServiceForSchoolAdminRole
    {
        public Task<JWTAuthenticationResponse> AddSchoolAdmin(SchoolAdmin schoolAdmin);
        public List<SchoolAdminDTO> GetAllSchoolAdminsBySchool(int schoolId);
        public SchoolAdminDTO GetSchoolAdminById(int schoolAdminId);
        public void UpdateSchoolAdmin(SchoolAdmin schoolAdmin);

    }
}
