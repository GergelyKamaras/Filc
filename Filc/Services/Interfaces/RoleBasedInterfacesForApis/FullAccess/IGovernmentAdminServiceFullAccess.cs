using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface IGovernmentAdminServiceFullAccess
    {
        public GovernmentAdmin GetGovernmentAdmin(int id);
        public List<GovernmentAdmin> GetAllGovernmentAdmins();
        public JWTAuthenticationResponse AddGovernmentAdmin(GovernmentAdmin governmentAdmin);
        public void RemoveGovernmentAdmin(int id);
        public void UpdateGovernmentAdmin(GovernmentAdmin governmentAdmin);
    }
}
