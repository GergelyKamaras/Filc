using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;

namespace Filc.Services.DataBaseQueryServices
{
    public class MarkSerice : IMarkService
    {
        private ESContext _db;
        public MarkSerice(ESContext esContext)
        {
            _db = esContext;
        }
        public Mark GetMark(int id)
        {
            return _db.Mark.First(x => x.Id == id);
        }
        public void AddMark(Mark mark)
        {
            _db.Mark.Add(mark);
            _db.SaveChanges();
        }

        public void UpdateMark(Mark mark)
        {
            _db.Mark.Update(mark);
            _db.SaveChanges();
        }

        public void DeleteMark(int id)
        {
            _db.Mark.Remove(_db.Mark.First(mark => mark.Id == id));
            _db.SaveChanges();
        }
        public List<Mark> GetMarksByStudent(int studentId)
        {
            return _db.Mark.Where(mark => mark.Student.Id == studentId).ToList();
        }

        public List<Mark> GetMarkByLesson(int lessonId)
        {
            return _db.Mark.Where(mark => mark.Lesson.Id == lessonId).ToList();
        }

        public List<Mark> GetMarksByLessonByStudent(int studentId, int lessonId)
        {
            return GetMarkByLesson(lessonId).Where(mark => mark.Student.Id == studentId).ToList();
        }
    }
}
