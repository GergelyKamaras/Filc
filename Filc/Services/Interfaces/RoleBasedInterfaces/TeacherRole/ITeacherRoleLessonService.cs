using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole
{
    public interface ITeacherRoleLessonService
    {
        public Lesson GetLessonById(int id);
        public List<Lesson> GetLessonByStudentId(int id);
        public List<Lesson> GetLessonsByTeacher(int id);
    }
}
