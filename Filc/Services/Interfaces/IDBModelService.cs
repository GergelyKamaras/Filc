using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces
{
    public interface IDBModelService
    {
        public School GetSchoolById(int? Id);
    }
}
