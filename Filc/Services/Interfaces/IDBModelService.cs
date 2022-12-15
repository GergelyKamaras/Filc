using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces
{
    public interface IDBModelService
    {
        public School GetSchoolById(int? Id);
        public bool SchoolNameExists(string name);
        public Student GetStudentById(int id);
    }
}
