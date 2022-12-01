using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Student
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<LessonViewModelShared>? Lessons { get; set; }
        public List<MarkViewModelShared>? Marks { get; set; }
        public SchoolViewModelShared School { get; set; }

        public StudentViewModel(EFDataAccessLibrary.Models.Student student)
        {
            Id = student.Id;
            user = student.user;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDate = student.BirthDate;
            Address = student.Address;
            School = new SchoolViewModelShared(student.School);
            Lessons = new List<LessonViewModelShared>();
            student.Lessons.ForEach(lesson => Lessons.Add(new LessonViewModelShared(lesson)));
            Marks = new List<MarkViewModelShared>();
            student.Marks.ForEach(mark => Marks.Add(new MarkViewModelShared(mark)));
        }
    }
}
