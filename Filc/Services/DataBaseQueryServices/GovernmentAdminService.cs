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
            List<GovernmentAdmin> governmentAdmins = _db.GovernmentAdmin.ToList();
            governmentAdmins.Add(governmentAdmin);
            _db.SaveChanges();
        }

        public void RemoveGovernmentAdmin(int id)
        {
            List<GovernmentAdmin> governmentAdmins = _db.GovernmentAdmin.ToList();
            var admin = governmentAdmins.First(x => x.Id == id);
            governmentAdmins.Remove(admin);
            _db.SaveChanges();
        }
        public void UpdateGovernmentAdmin(GovernmentAdmin governmentAdmin)
        {
            List<GovernmentAdmin> governmentAdmins = _db.GovernmentAdmin.ToList();
            var oldAdmin = governmentAdmins.First(x => x.Id == governmentAdmin.Id);
            oldAdmin = governmentAdmin;
            _db.SaveChanges();
        }
    }
}
