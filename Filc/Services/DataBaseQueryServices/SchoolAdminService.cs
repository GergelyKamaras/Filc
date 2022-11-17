using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class SchoolAdminService : ISchoolAdminService
    {
        private ESContext _db;
        private IUserService _userService;
        public SchoolAdminService(ESContext esContext, IUserService userService)
        {
            _userService = userService;
            _db = esContext;
        }
        public void AddSchoolAdmin(SchoolAdmin schoolAdmin, string email)
        {
            IdentityUser user = _userService.GetUserByEmail(email);
            schoolAdmin.user = user;
            _db.SchoolAdmin.Add(schoolAdmin);
            _db.SaveChanges();
        }
        public SchoolAdmin GetSchoolAdmin(int schoolAdminId)
        {
            return _db.SchoolAdmin.Include(admin => admin.user)
                .First(x => x.Id == schoolAdminId);
        }

        public void UpdateSchoolAdmin(SchoolAdmin schoolAdmin)
        {
            _db.SchoolAdmin.Update(schoolAdmin);
            _db.SaveChanges();
        }

        public void DeleteSchoolAdmin(int schoolAdminId)
        {
            _db.SchoolAdmin.Remove(_db.SchoolAdmin.First(admin => admin.Id == schoolAdminId));
            _db.SaveChanges();
        }
    }
}
