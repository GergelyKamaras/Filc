using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IParentService : IParentRoleParentService
    {
        public Parent GetParent(int id);
        public void AddParent(Parent parent);
        public void UpdateParent(Parent parent);
        public void DeleteParent(int id);
    }
}
