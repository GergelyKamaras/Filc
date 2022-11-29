using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class SchoolAdminTableQueryService : ISchoolAdminServiceFullAccess
    {
        private ESContext _db;
        private IUserServiceFullAccess _userService;
        public SchoolAdminTableQueryService(ESContext esContext, IUserServiceFullAccess userService)
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

        public List<SchoolAdmin> GetAllSchoolAdmins()
        {
            return _db.SchoolAdmin.ToList();
        }

        public List<SchoolAdmin> GetAllSchoolAdminsBySchool(int schoolId)
        {
            return _db.SchoolAdmin.Where(admin => admin.School.Id == schoolId)
                .Include(admin => admin.user)
                .ToList();
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
