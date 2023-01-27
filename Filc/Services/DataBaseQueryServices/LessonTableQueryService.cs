using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
using Filc.Models.ViewModels.Lesson;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class LessonTableQueryService : ILessonServiceFullAccess
    {
        private ESContext _db;
        public LessonTableQueryService(ESContext esContext)
        {
            _db = esContext;
        }
        public LessonDTO GetLessonById(int id)
        {
            Lesson lesson = _db.Lesson.Include(lesson => lesson.School)
                .Include(lesson => lesson.Teachers)
                .Include(lesson => lesson.students)
                .Include(lesson => lesson.Subject)
                .FirstOrDefault(lesson => lesson.Id == id);
            if (lesson != null) 
            {
                return new LessonDTO(lesson);
            }
            else
            {
                throw new KeyNotFoundException(message:"Lesson not found.");
            }
        }

        public List<LessonDTO> GetLessonByStudentId(int id)
        {
            List<Lesson> lessons = _db.Lesson.Include(lesson => lesson.School)
                            .Include(lesson => lesson.Teachers)
                            .Include(lesson => lesson.students)
                            .Include(lesson => lesson.Subject)
                            .Where(lesson => lesson.students.Select(s => s.Id).Any(studentId => studentId == id)).ToList();
            return ModelConverter.ModelConverter.MapLessonsToLessonViewModels(lessons);
        }

        public List<LessonDTO> GetLessonsByTeacher(int id)
        {
            List<Lesson> lessons = _db.Lesson.Include(lesson => lesson.School)
                            .Include(lesson => lesson.Teachers)
                            .Include(lesson => lesson.students)
                            .Include(lesson => lesson.Subject)
                            .Where(lesson => lesson.Teachers.Select(t => t.Id).Any(teacherId => teacherId == id)).ToList();
            return ModelConverter.ModelConverter.MapLessonsToLessonViewModels(lessons);
        }

        public JWTAuthenticationResponse AddLesson(Lesson lesson)
        {
            lesson.School = _db.School.First(s => s.Id == lesson.School.Id);
            
            for (int i = 0; i < lesson.students.Count; i++)
            {
                lesson.students[i] = _db.Student.First(s => s.Id == lesson.students[i].Id);
            }

            for (int i = 0; i < lesson.Teachers.Count; i++)
            {
                lesson.Teachers[i] = _db.Teacher.First(t => t.Id == lesson.Teachers[i].Id);
            }
            
            _db.Lesson.Add(lesson);
            _db.SaveChanges();
            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration successful!",
                Id = lesson.Id
            };
        }

        public void UpdateLesson(Lesson lesson)
        {
            lesson.School = _db.School.First(s => s.Id == lesson.School.Id);

            for (int i = 0; i < lesson.students.Count; i++)
            {
                lesson.students[i] = _db.Student.First(s => s.Id == lesson.students[i].Id);
            }

            for (int i = 0; i < lesson.Teachers.Count; i++)
            {
                lesson.Teachers[i] = _db.Teacher.First(t => t.Id == lesson.Teachers[i].Id);
            }

            _db.Lesson.Update(lesson);
            _db.SaveChanges();
        }

        public void DeleteLesson(int id)
        {
            var lesson = _db.Lesson.FirstOrDefault(x => x.Id == id);
            if (lesson != null)
            {
                _db.Lesson.Remove(lesson);
                _db.SaveChanges();
            }

        }
    }
}
