using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.ViewModels.Shared
{
    public class LessonViewModelShared
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubjectViewModelShared Subject { get; set; }
        public LessonViewModelShared(EFDataAccessLibrary.Models.Lesson lesson)
        {
            Id = lesson.Id;
            Name = lesson.Name;
            Subject = new SubjectViewModelShared(lesson.Subject);
        }
    }
}
