using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class GovernmentAdminService : IGovernmentAdminService
    {
        private ESContext _db;
        public GovernmentAdminService(ESContext esContext)
        {
            _db = esContext;
        }
        public GovernmentAdmin GetGovernmentAdmin(int id)
        {
            return _db.GovernmentAdmin.First(x => x.Id == id);
        }
        public void AddGovernmentAdmin(GovernmentAdmin governmentAdmin)
        {
            _db.GovernmentAdmin.Add(governmentAdmin);
            _db.SaveChanges();
        }
        public void RemoveGovernmentAdmin(int id)
        {
            _db.GovernmentAdmin.Remove(_db.GovernmentAdmin.First(x => x.Id == id));
            _db.SaveChanges();
        }
        public void UpdateGovernmentAdmin(GovernmentAdmin governmentAdmin)
        {
            _db.GovernmentAdmin.Update(governmentAdmin);
            _db.SaveChanges();
        }
    }
}
