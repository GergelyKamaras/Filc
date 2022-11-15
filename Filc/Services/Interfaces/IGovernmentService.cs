namespace Filc.Services.Interfaces
{
    public interface IGovernmentService
    {
        public void AddSchool(School school);
        public void RemoveSchool(int id);
        public List<School> ReturnAllSchools();
        public void AddSchoolAdmin(int schoolId, SchoolAdmin schoolAdmin);
    }
}
