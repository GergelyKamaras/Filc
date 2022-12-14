using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces;
using System.Linq;

namespace Filc.Services.DataBaseQueryServices
{
    public class DBModelService : IDBModelService
    {
        private ESContext _db;
        public DBModelService(ESContext dbContext)
        {
            _db = dbContext;
        }

        public School GetSchoolById(int? id)
        {
            return _db.School.FirstOrDefault(s => s.Id == id);
        }
    }
}
