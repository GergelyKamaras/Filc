using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Teacher
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<SubjectViewModelShared>? Subjects { get; set; }
        public List<LessonViewModelShared>? Lessons { get; set; }
        public SchoolViewModelShared School { get; set; }

        public TeacherViewModel(EFDataAccessLibrary.Models.Teacher teacher)
        {
            Id = teacher.Id;
            user = teacher.user;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            BirthDate = teacher.BirthDate;
            Address = teacher.Address;

            Subjects = new List<SubjectViewModelShared>();
            teacher.Subjects.ForEach(subject => Subjects.Add(new SubjectViewModelShared(subject)));

            Lessons = new List<LessonViewModelShared>();
            teacher.Lessons.ForEach(lesson => Lessons.Add(new LessonViewModelShared(lesson)));

            School = new SchoolViewModelShared(teacher.School);
        }
    }
}
