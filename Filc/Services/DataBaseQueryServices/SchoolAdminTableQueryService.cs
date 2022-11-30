using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class SchoolAdminTableQueryService : ISchoolAdminServiceFullAccess
    {
        private readonly ESContext _db;
        private readonly IUserServiceFullAccess _userService;
        public SchoolAdminTableQueryService(ESContext esContext, IUserServiceFullAccess userService)
        {
            _userService = userService;
            _db = esContext;
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

        public SchoolAdmin GetSchoolAdminById(int id)
        {
            return _db.SchoolAdmin.Include(admin => admin.user)
                .First(x => x.Id == id);
        }

        public void AddSchoolAdmin(SchoolAdmin schoolAdmin)
        {
            ApplicationUser user = _userService.GetUserByEmail(schoolAdmin.user.Email);
            if(user.Email != null)
            {
                schoolAdmin.user = user;
                _db.SchoolAdmin.Add(schoolAdmin);
                _db.SaveChanges();
            }     
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

        public SchoolAdmin GetASchoolAdmin()
        {
            return new SchoolAdmin
            {
                FirstName = "ads",
                user = new ApplicationUser
                {
                    Email = "asd@asd.hu"
                }
            };
        }
    }
}
