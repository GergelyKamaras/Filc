using EFDataAccessLibrary.Models;
using Filc.Models.DTOs.Shared;
using Filc.Models.EntityViewModels.Subject;

namespace Filc.Models.EntityViewModels.Teacher
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<EFDataAccessLibrary.Models.Subject>? Subjects { get; set; }
        public List<LessonSharedDTO>? Lessons { get; set; }
        public SchoolSharedDTO School { get; set; }

        public TeacherDTO(EFDataAccessLibrary.Models.Teacher teacher)
        {
            Id = teacher.Id;
            user = teacher.user;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            BirthDate = teacher.BirthDate;
            Address = teacher.Address;

            var Subjects = new List<SubjectDTO>();
            teacher.Subjects.ForEach(subject => Subjects.Add(new SubjectDTO(subject)));

            Lessons = new List<LessonSharedDTO>();
            teacher.Lessons.ForEach(lesson => Lessons.Add(new LessonSharedDTO(lesson)));

            School = new SchoolSharedDTO(teacher.School);
        }
    }
}
