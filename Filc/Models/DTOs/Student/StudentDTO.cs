using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Student
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<LessonSharedDTO>? Lessons { get; set; }
        public List<MarkSharedDTO>? Marks { get; set; }
        public SchoolSharedDTO School { get; set; }

        public StudentDTO(EFDataAccessLibrary.Models.Student student)
        {
            Id = student.Id;
            user = student.User;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDate = student.BirthDate;
            Address = student.Address;
            School = new SchoolSharedDTO(student.School);
            Lessons = new List<LessonSharedDTO>();
            student.Lessons.ForEach(lesson => Lessons.Add(new LessonSharedDTO(lesson)));
            Marks = new List<MarkSharedDTO>();
            student.Marks.ForEach(mark => Marks.Add(new MarkSharedDTO(mark)));
        }
    }
}
