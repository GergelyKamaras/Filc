using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Lesson;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface ILessonServiceForTeacherRole
    {
        public LessonViewModel GetLessonById(int id);
        public List<LessonViewModel> GetLessonByStudentId(int id);
        public List<LessonViewModel> GetLessonsByTeacher(int id);
    }
}
