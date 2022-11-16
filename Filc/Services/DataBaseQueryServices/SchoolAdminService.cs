using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;

namespace Filc.Services.DataBaseQueryServices
{
    public class SchoolAdminService : ISchoolAdminService
    {
        private ESContext _db;
        public SchoolAdminService(ESContext esContext)
        {
            _db = esContext;
        }
        public void AddSchoolAdmin(SchoolAdmin schoolAdmin)
        {
            _db.SchoolAdmin.Add(schoolAdmin);
            _db.SaveChanges();
        }
        public SchoolAdmin GetSchoolAdmin(int schoolAdminId)
        {
            return _db.SchoolAdmin.First(x => x.Id == schoolAdminId);
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
