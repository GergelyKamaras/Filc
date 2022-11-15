using Microsoft.AspNetCore.Identity;

namespace Filc.Services.Interfaces
{
    // Class containing methods that are used by multiple school member users
    public interface ISchoolSharedService
    {
        public IUser GetUser(UserRole userRole, int userId);
        public Lesson GetLesson(int lessonId);
    }
}
