using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Mark
{
    public class MarkDTO
    {
        public int Id { get; set; }
        public TeacherSharedDTO Teacher { get; set; }
        public StudentSharedDTO Student { get; set; }
        public float Grade { get; set; }
        public string Description { get; set; }
        public LessonSharedDTO Lesson { get; set; }
        public SubjectSharedDTO Subject { get; set; }
        public DateTime Date { get; set; }

        public MarkDTO(EFDataAccessLibrary.Models.Mark mark)
        {
            Grade = mark.Grade;
            Description = mark.Description;
            Date = mark.Date;
            Subject = new SubjectSharedDTO(mark.Subject);
            Teacher = new TeacherSharedDTO(mark.Teacher);
            Student = new StudentSharedDTO(mark.Student);
            Lesson = new LessonSharedDTO(mark.Lesson);
        }
    }
}
