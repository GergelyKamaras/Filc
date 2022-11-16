using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole
{
    public interface IParentRoleParentService
    {
        public Parent GetParent(int id);
        public void UpdateParent(Parent parent);
    }
}
