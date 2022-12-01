using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Lesson
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public List<StudentViewModelShared> students { get; set; }
        public List<TeacherViewModelShared> Teachers { get; set; }
        public SchoolViewModelShared School { get; set; }

        public LessonViewModel(EFDataAccessLibrary.Models.Lesson lesson)
        {
            Id = lesson.Id;
            Name = lesson.Name;
            Subject = lesson.Subject;
            students = new List<StudentViewModelShared>();
            lesson.students.ForEach(student => students.Add(new StudentViewModelShared(student)));
            Teachers = new List<TeacherViewModelShared>();
            lesson.Teachers.ForEach(teacher => Teachers.Add(new TeacherViewModelShared(teacher)));
            School = new SchoolViewModelShared(lesson.School);
        }
    }
}
