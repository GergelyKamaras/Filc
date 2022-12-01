using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Shared;
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
        public List<SchoolAdminViewModelShared> SchoolAdmin { get; set; }
        public List<StudentViewModelShared> Students { get; set; }
        public List<SubjectViewModelShared> Subjects { get; set; }
        public List<LessonViewModelShared> Lessons { get; set; }
        public List<TeacherViewModelShared> Teachers { get; set; }
        public List<SchoolClassViewModelShared> Classes { get; set; }

        public SchoolViewModel(EFDataAccessLibrary.Models.School school)
        {
            Id = school.Id;
            Name = school.Name;
            Address = school.Address;
            SchoolType = school.SchoolType;

            SchoolAdmin = new List<SchoolAdminViewModelShared>();
            school.SchoolAdmin.ForEach(admin => SchoolAdmin.Add(new SchoolAdminViewModelShared(admin)));

            Students = new List<StudentViewModelShared>();
            school.Students.ForEach(student => Students.Add(new StudentViewModelShared(student)));

            Subjects = new List<SubjectViewModelShared>();
            school.Subjects.ForEach(subject => Subjects.Add(new SubjectViewModelShared(subject)));

            Lessons = new List<LessonViewModelShared>();
            school.Lessons.ForEach(lesson => Lessons.Add(new LessonViewModelShared(lesson)));
            
            Teachers = new List<TeacherViewModelShared>();
            school.Teachers.ForEach(teacher => Teachers.Add(new TeacherViewModelShared(teacher)));

            Classes = new List<SchoolClassViewModelShared>();
            school.Classes.ForEach(schoolClass => Classes.Add(new SchoolClassViewModelShared(schoolClass)));
        }
    }
}
