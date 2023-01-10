using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Lesson
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public List<StudentSharedDTO> Students { get; set; }
        public List<TeacherSharedDTO> Teachers { get; set; }
        public SchoolSharedDTO School { get; set; }

        public LessonDTO(EFDataAccessLibrary.Models.Lesson lesson)
        {
            Id = lesson.Id;
            Name = lesson.Name;
            Subject = lesson.Subject;
            Students = new List<StudentSharedDTO>();
            lesson.students.ForEach(student => Students.Add(new StudentSharedDTO(student)));
            Teachers = new List<TeacherSharedDTO>();
            lesson.Teachers.ForEach(teacher => Teachers.Add(new TeacherSharedDTO(teacher)));
            School = new SchoolSharedDTO(lesson.School);
        }
    }
}
