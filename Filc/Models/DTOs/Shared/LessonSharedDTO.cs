using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.ViewModels.Shared
{
    public class LessonSharedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubjectSharedDTO Subject { get; set; }
        public LessonSharedDTO(EFDataAccessLibrary.Models.Lesson lesson)
        {
            Id = lesson.Id;
            Name = lesson.Name;
            Subject = new SubjectSharedDTO(lesson.Subject);
        }
    }
}
