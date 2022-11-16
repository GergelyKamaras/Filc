using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.ModelInterfaces;

namespace Filc.Services.Interfaces
{
    // Class containing methods that are used by multiple school member users
    public interface ISchoolSharedService
    {
        
        public Lesson GetLesson(int lessonId);
    }
}
