﻿using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;

namespace Filc.Services.DataBaseQueryServices
{
    public class LessonService : ILessonService
    {
        private ESContext _db;
        public LessonService(ESContext esContext)
        {
            _db = esContext;
        }
        public Lesson GetLessonById(int id)
        {
            return _db.Lesson.First(lesson => lesson.Id == id);
        }

        public List<Lesson> GetLessonByStudentId(int id)
        {
            return _db.Lesson.Where(lesson => lesson.students.Exists(student => student.Id == id)).ToList();
        }

        public List<Lesson> GetLessonsByTeacher(int id)
        {
            return _db.Lesson.Where(lesson => lesson.Teachers.Exists(teacher => teacher.Id == id)).ToList();
        }

        public void AddLesson(Lesson lesson)
        {
            _db.Lesson.Add(lesson);
            _db.SaveChanges();
        }

        public void UpdateLesson(Lesson lesson)
        {
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