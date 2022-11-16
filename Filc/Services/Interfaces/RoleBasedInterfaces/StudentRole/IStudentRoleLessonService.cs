using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole
{
    public interface IStudentRoleLessonService
    {
        public Lesson GetLessonById(int id);
        public List<Lesson> GetLessonByStudentId(int id);
    }
}
