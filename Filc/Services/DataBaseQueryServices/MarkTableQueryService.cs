using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
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
        public MarkDTO GetMark(int id)
        {
            Mark mark = _db.Mark.Include(mark => mark.Lesson)
                .Include(mark => mark.Student)
                .Include(mark => mark.Teacher)
                .Include(mark => mark.Subject)
                .First(x => x.Id == id);
            return new MarkDTO(mark);
        }
        public JWTAuthenticationResponse AddMark(Mark mark)
        {
            mark.Lesson = _db.Lesson.First(l => l.Id == mark.Lesson.Id);
            mark.Student = _db.Student.First(s => s.Id == mark.Student.Id);
            mark.Teacher = _db.Teacher.First(t => t.Id == mark.Teacher.Id);
            _db.Mark.Add(mark);
            _db.SaveChanges();
            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration successful!",
                Id = mark.Id
            };
        }
        public void UpdateMark(Mark mark)
        {
            mark.Lesson = _db.Lesson.First(l => l.Id == mark.Lesson.Id);
            mark.Student = _db.Student.First(s => s.Id == mark.Student.Id);
            mark.Teacher = _db.Teacher.First(t => t.Id == mark.Teacher.Id);
            _db.Mark.Update(mark);
            _db.SaveChanges();
        }
        public void DeleteMark(int id)
        {
            _db.Mark.Remove(_db.Mark.First(mark => mark.Id == id));
            _db.SaveChanges();
        }
        public List<MarkDTO> GetMarksByStudent(int studentId)
        {
            List<Mark> marks = _db.Mark.Include(mark => mark.Lesson)
                .Include(mark => mark.Student)
                .Include(mark => mark.Teacher)
                .Include(mark => mark.Subject)
                .Where(mark => mark.Student.Id == studentId).ToList();
            return ModelConverter.ModelConverter.MapMarksToMarkViewModels(marks);
        }
        public List<MarkDTO> GetMarkByLesson(int lessonId)
        {
            List<Mark> marks = _db.Mark.Where(mark => mark.Lesson.Id == lessonId).Include(mark => mark.Lesson)
                .Include(mark => mark.Student)
                .Include(mark => mark.Teacher)
                .Include(mark => mark.Subject).ToList();
            return ModelConverter.ModelConverter.MapMarksToMarkViewModels(marks);
        }
    }
}
