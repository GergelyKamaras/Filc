using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;

namespace Filc.Services.DataBaseQueryServices
{
    public class ParentService : IParentService
    {
        private ESContext _db;
        public ParentService(ESContext esContext)
        {
            _db = esContext;
        }
        public Parent GetParent(int id)
        {
            return _db.Parent.First(parent => parent.Id == id);
        }

        public void AddParent(Parent parent)
        {
            _db.Parent.Add(parent);
            _db.SaveChanges();
        }

        public void UpdateParent(Parent parent)
        {
            _db.Parent.Update(parent);
            _db.SaveChanges();
        }

        public void DeleteParent(int id)
        {
            _db.Parent.Remove(_db.Parent.First(parent => parent.Id == id));
        }
    }
}
