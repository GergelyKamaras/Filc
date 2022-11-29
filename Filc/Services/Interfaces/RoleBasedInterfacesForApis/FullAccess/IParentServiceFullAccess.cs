using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface IParentServiceFullAccess : IParentServiceForParentRole
    {
        public void AddParent(Parent parent);
        public void DeleteParent(int id);
    }
}
