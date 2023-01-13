using Filc.Models.DTOs.Shared;
using Filc.Models.EntityViewModels.Subject;

namespace Filc.Models.EntityViewModels.School
{
    public class SchoolDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string SchoolType { get; set; }
        public List<SchoolAdminSharedDTO> SchoolAdmin { get; set; }
        public List<StudentSharedDTO> Students { get; set; }
        public List<SubjectDTO> Subjects { get; set; }
        public List<LessonSharedDTO> Lessons { get; set; }
        public List<TeacherSharedDTO> Teachers { get; set; }
        public List<SchoolClassSharedDTO> Classes { get; set; }

        public SchoolDTO(EFDataAccessLibrary.Models.School school)
        {
            Id = school.Id;
            Name = school.Name;
            Address = school.Address;
            SchoolType = school.SchoolType;

            SchoolAdmin = new List<SchoolAdminSharedDTO>();
            school.SchoolAdmin.ForEach(admin => SchoolAdmin.Add(new SchoolAdminSharedDTO(admin)));

            Students = new List<StudentSharedDTO>();
            school.Students.ForEach(student => Students.Add(new StudentSharedDTO(student)));

            Subjects = new List<SubjectDTO>();
            school.Subjects.ForEach(subject => Subjects.Add(new SubjectDTO(subject)));

            Lessons = new List<LessonSharedDTO>();
            school.Lessons.ForEach(lesson => Lessons.Add(new LessonSharedDTO(lesson)));
            
            Teachers = new List<TeacherSharedDTO>();
            school.Teachers.ForEach(teacher => Teachers.Add(new TeacherSharedDTO(teacher)));

            Classes = new List<SchoolClassSharedDTO>();
            school.Classes.ForEach(schoolClass => Classes.Add(new SchoolClassSharedDTO(schoolClass)));
        }
    }
}
