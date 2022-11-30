using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.EntityViewModels.School
{
    public class LessonViewModelForSchool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public LessonViewModelForSchool(Lesson lesson)
        {
            Id = lesson.Id;
            Name = lesson.Name;
            Subject = lesson.Subject;
        }
    }
}
