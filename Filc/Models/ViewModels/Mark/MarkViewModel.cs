using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Mark
{
    public class MarkViewModel
    {
        public int Id { get; set; }
        public TeacherViewModelShared Teacher { get; set; }
        public StudentViewModelShared Student { get; set; }
        public float Grade { get; set; }
        public string Description { get; set; }
        public LessonViewModelShared Lesson { get; set; }
        public SubjectViewModelShared Subject { get; set; }
        public DateTime Date { get; set; }

        public MarkViewModel(EFDataAccessLibrary.Models.Mark mark)
        {
            Grade = mark.Grade;
            Description = mark.Description;
            Date = mark.Date;
            Subject = new SubjectViewModelShared(mark.Subject);
            Teacher = new TeacherViewModelShared(mark.Teacher);
            Student = new StudentViewModelShared(mark.Student);
            Lesson = new LessonViewModelShared(mark.Lesson);
        }
    }
}
