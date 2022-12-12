﻿using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
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
                .First(lesson => lesson.Id == id);
            return new LessonDTO(lesson);
        }

        public List<LessonDTO> GetLessonByStudentId(int id)
        {
            List<Lesson> lessons = _db.Lesson.Include(lesson => lesson.School)
                .Include(lesson => lesson.Teachers)
                .Include(lesson => lesson.students)
                .Include(lesson => lesson.Subject)
                .Where(lesson => lesson.students.Exists(student => student.Id == id)).ToList();
            return ModelConverter.ModelConverter.MapLessonsToLessonViewModels(lessons);
        }

        public List<LessonDTO> GetLessonsByTeacher(int id)
        {
            List<Lesson> lessons = _db.Lesson.Include(lesson => lesson.School)
                .Include(lesson => lesson.Teachers)
                .Include(lesson => lesson.students)
                .Include(lesson => lesson.Subject)
                .Where(lesson => lesson.Teachers.Exists(teacher => teacher.Id == id)).ToList();
            return ModelConverter.ModelConverter.MapLessonsToLessonViewModels(lessons);
        }

        public void AddLesson(Lesson lesson)
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
            _db.Lesson.Remove(_db.Lesson.First(x => x.Id == id));
            _db.SaveChanges();
        }
    }
}
