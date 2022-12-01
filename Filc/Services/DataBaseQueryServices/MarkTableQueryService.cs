using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Mark;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class MarkTableQueryService : IMarkServiceFullAccess
    {
        private ESContext _db;
        public MarkTableQueryService(ESContext esContext)
        {
            _db = esContext;
        }
        public MarkViewModel GetMark(int id)
        {
            Mark mark = _db.Mark.Include(mark => mark.Lesson)
                .Include(mark => mark.Student)
                .Include(mark => mark.Teacher)
                .Include(mark => mark.Subject)
                .First(x => x.Id == id);
            return new MarkViewModel(mark);
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
        public List<MarkViewModel> GetMarksByStudent(int studentId)
        {
            List<Mark> marks = _db.Mark.Include(mark => mark.Lesson)
                .Include(mark => mark.Student)
                .Include(mark => mark.Teacher)
                .Include(mark => mark.Subject)
                .Where(mark => mark.Student.Id == studentId).ToList();
            return ModelConverter.ModelConverter.MapMarksToMarkViewModels(marks);
        }
        public List<MarkViewModel> GetMarkByLesson(int lessonId)
        {
            List<Mark> marks = _db.Mark.Where(mark => mark.Lesson.Id == lessonId).Include(mark => mark.Lesson)
                .Include(mark => mark.Student)
                .Include(mark => mark.Teacher)
                .Include(mark => mark.Subject).ToList();
            return ModelConverter.ModelConverter.MapMarksToMarkViewModels(marks);
        }
    }
}
