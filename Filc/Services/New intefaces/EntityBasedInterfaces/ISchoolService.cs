using EFDataAccessLibrary.Models;

namespace Filc.Services.New_intefaces.EntityBasedInterfaces
{
    public interface ISchoolService
    {
        public void AddSchool(School school);
        public void RemoveSchool(int id);
        public List<School> ReturnAllSchools();
    }
}
