using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ILessonService
    {
        public Lesson GetLessonById(int id);
        public List<Lesson> GetLessonByStudentId(int id);
        public List<Lesson> GetLessonsByTeacher(int id);
        public void AddLesson(Lesson lesson);
        public void UpdateLesson(Lesson lesson);
        public void DeleteLesson(int id);
    }
}
