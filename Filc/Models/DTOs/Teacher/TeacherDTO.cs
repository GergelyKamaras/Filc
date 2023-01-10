using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Teacher
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<SubjectSharedDTO>? Subjects { get; set; }
        public List<LessonSharedDTO>? Lessons { get; set; }
        public SchoolSharedDTO School { get; set; }

        public TeacherDTO(EFDataAccessLibrary.Models.Teacher teacher)
        {
            Id = teacher.Id;
            user = teacher.User;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            BirthDate = teacher.BirthDate;
            Address = teacher.Address;

            Subjects = new List<SubjectSharedDTO>();
            teacher.Subjects.ForEach(subject => Subjects.Add(new SubjectSharedDTO(subject)));

            Lessons = new List<LessonSharedDTO>();
            teacher.Lessons.ForEach(lesson => Lessons.Add(new LessonSharedDTO(lesson)));

            School = new SchoolSharedDTO(teacher.School);
        }
    }
}
