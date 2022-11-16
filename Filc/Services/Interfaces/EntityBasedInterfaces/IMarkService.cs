using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IMarkService
    {
        public Mark GeMark(int id);
        public void AddMark(Mark mark);
        public void UpdateMark(Mark mark);
        public void DeleteMark(int id);
        public List<Mark> GetMarksByStudent(int studentId);
        public List<Mark> GetMarkByLesson(int lessonId);
        public List<Mark> GetMarksByLessonByStudent(int studentId, int lessonId);
    }
}
