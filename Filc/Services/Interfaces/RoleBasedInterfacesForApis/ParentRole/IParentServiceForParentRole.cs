using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole
{
    public interface IParentServiceForParentRole
    {
        public Parent GetParent(int id);
        public void UpdateParent(Parent parent);
    }
}
