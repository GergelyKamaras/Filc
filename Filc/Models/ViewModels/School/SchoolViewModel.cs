using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Filc.Models.EntityViewModels.School
{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string SchoolType { get; set; }
        public List<SchoolAdminViewModelForSchool> SchoolAdmin { get; set; }
        public List<StudentViewModelForSchool> Students { get; set; }
        public List<SubjectViewModelForSchool> Subjects { get; set; }
        public List<LessonViewModelForSchool> Lessons { get; set; }
        public List<TeacherViewModelForSchool> Teachers { get; set; }
        public List<SchoolClassViewModelForSchool> Classes { get; set; }

        public SchoolViewModel(EFDataAccessLibrary.Models.School school)
        {
            Id = school.Id;
            Name = school.Name;
            Address = school.Address;
            SchoolType = school.SchoolType;

            SchoolAdmin = new List<SchoolAdminViewModelForSchool>();
            school.SchoolAdmin.ForEach(admin => SchoolAdmin.Add(new SchoolAdminViewModelForSchool(admin)));

            Students = new List<StudentViewModelForSchool>();
            school.Students.ForEach(student => Students.Add(new StudentViewModelForSchool(student)));

            Subjects = new List<SubjectViewModelForSchool>();
            school.Subjects.ForEach(subject => Subjects.Add(new SubjectViewModelForSchool(subject)));

            Lessons = new List<LessonViewModelForSchool>();
            school.Lessons.ForEach(lesson => Lessons.Add(new LessonViewModelForSchool(lesson)));
            
            Teachers = new List<TeacherViewModelForSchool>();
            school.Teachers.ForEach(teacher => Teachers.Add(new TeacherViewModelForSchool(teacher)));

            Classes = new List<SchoolClassViewModelForSchool>();
            school.Classes.ForEach(schoolClass => Classes.Add(new SchoolClassViewModelForSchool(schoolClass)));
        }
    }
}
