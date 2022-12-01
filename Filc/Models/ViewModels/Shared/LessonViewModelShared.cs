using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.ViewModels.Shared
{
    public class LessonViewModelShared
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public LessonViewModelShared(Lesson lesson)
        {
            Id = lesson.Id;
            Name = lesson.Name;
            Subject = lesson.Subject;
        }
    }
}
