using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
using Filc.Models.ViewModels.Mark;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.EntityFrameworkCore;
using Filc.Models.ViewModels.Shared;
using System.ComponentModel.DataAnnotations;

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
            if (_db.Student.FirstOrDefault(s=>s.Id == studentId) == null)
            {
                throw new Exception("Student ID not found.");
            }
            else
            {
                return ModelConverter.ModelConverter.MapMarksToMarkViewModels(marks);
            }
            
        }
        public List<MarkDTO> GetMarkByLesson(int lessonId)
        {
            List<Mark> marks = _db.Mark.Where(mark => mark.Lesson.Id == lessonId).Include(mark => mark.Lesson)
                .Include(mark => mark.Student)
                .Include(mark => mark.Teacher)
                .Include(mark => mark.Subject).ToList();
            if (_db.Lesson.FirstOrDefault(l=>l.Id==lessonId) == null)
            {
                throw new KeyNotFoundException("Lesson ID not found.");
            }
            else
            {
                return ModelConverter.ModelConverter.MapMarksToMarkViewModels(marks);
            }
            
        }


}
}
