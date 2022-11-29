using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IParentServiceFullAccess : IParentServiceForParentRole
    {
        public void AddParent(Parent parent);
        public void DeleteParent(int id);
    }
}
