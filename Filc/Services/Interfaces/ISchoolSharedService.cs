using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.ModelInterfaces;

namespace Filc.Services.Interfaces
{
    // Class containing methods that are used by multiple school member users
    public interface ISchoolSharedService
    {
        public IUser GetUser(string userRole, int userId);
        public Lesson GetLesson(int lessonId);
    }
}
