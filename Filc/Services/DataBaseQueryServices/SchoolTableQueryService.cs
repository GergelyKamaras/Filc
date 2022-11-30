using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class SchoolTableQueryService : ISchoolServiceFullAccess
    {
        private ESContext _db;
        public SchoolTableQueryService(ESContext esContext)
        {
            _db = esContext;
        }

        public void AddSchool(School school)
        {
            _db.School.Add(school);
            _db.SaveChanges();
        }

        public SchoolViewModel GetSchool(int id)
        {
            School school = _db.School.Include(school => school.Classes)
                .Include(school => school.Lessons)
                .Include(school => school.SchoolAdmin)
                .Include(school => school.Students)
                .Include(school => school.Subjects)
                .Include(school => school.Teachers)
                .First(x => x.Id == id);
            
            return new SchoolViewModel(school);
        }
        public List<SchoolViewModel> GetAllSchools()
        {
            List<School> schools = _db.School.Include(school => school.Classes)
                .Include(school => school.Lessons)
                .Include(school => school.SchoolAdmin)
                .Include(school => school.Students)
                .Include(school => school.Subjects)
                .Include(school => school.Teachers)
                .ToList();
            return ModelConverter.ModelConverter.MapSchoolToSchoolViewModel(schools);
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
