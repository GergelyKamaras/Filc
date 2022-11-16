using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IParentService
    {
        public Parent GetParent(int id);
        public void AddParent(Parent parent);
        public void UpdateParent(Parent parent);
        public void DeleteParent(int id);
    }
}
