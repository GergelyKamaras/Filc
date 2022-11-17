using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class GovernmentAdminService : IGovernmentAdminService
    {
        private ESContext _db;
        private IUserService _userService;
        public GovernmentAdminService(ESContext esContext, IUserService usrService)
        {
            _db = esContext;
            _userService = usrService;
        }

        public List<GovernmentAdmin> GetAllGovernmentAdmins()
        {
            return _db.GovernmentAdmin.Include(admin => admin.user)
                .ToList();
        }
        public GovernmentAdmin GetGovernmentAdmin(int id)
        {
            return _db.GovernmentAdmin.Include(admin => admin.user)
                .First(x => x.Id == id);
        }
        public void AddGovernmentAdmin(GovernmentAdmin governmentAdmin, string email)
        {
            IdentityUser user = _userService.GetUserByEmail(email);
            governmentAdmin.user = user;
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
