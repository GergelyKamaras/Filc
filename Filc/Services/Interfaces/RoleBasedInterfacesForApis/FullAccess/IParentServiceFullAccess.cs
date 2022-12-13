using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface IParentServiceFullAccess : IParentServiceForParentRole
    {
        public JWTAuthenticationResponse AddParent(Parent parent);
        public void DeleteParent(int id);
    }
}
