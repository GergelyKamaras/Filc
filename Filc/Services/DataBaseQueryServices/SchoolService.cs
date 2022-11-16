using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;

namespace Filc.Services.DataBaseQueryServices
{
    public class SchoolService : ISchoolService
    {
        private ESContext _db;
        public SchoolService(ESContext esContext)
        {
            _db = esContext;
        }

        public void AddSchool(School school)
        {
            _db.School.Add(school);
            _db.SaveChanges();
        }

        public School GetSchool(int id)
        {
            return _db.School.First(x => x.Id == id);
        }
        public List<School> GetAllSchools()
        {
            return _db.School.ToList();
        }

        public void RemoveSchool(int id)
        {
            _db.School.Remove(_db.School.First(school => school.Id == id));
            _db.SaveChanges();
        }

        public void UpdateSchool(School school)
    {
            _db.School.Update(school);
            _db.SaveChanges();
        }
    }
}
