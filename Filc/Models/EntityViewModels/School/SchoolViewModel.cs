using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;

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
    }
}
