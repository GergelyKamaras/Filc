using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole
{
    public interface ILessonServiceForTeacherRole
    {
        public Lesson GetLessonById(int id);
        public List<Lesson> GetLessonByStudentId(int id);
        public List<Lesson> GetLessonsByTeacher(int id);
    }
}
