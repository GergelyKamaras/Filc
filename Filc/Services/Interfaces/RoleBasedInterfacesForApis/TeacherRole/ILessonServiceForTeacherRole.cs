using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Lesson;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface ILessonServiceForTeacherRole
    {
        public LessonDTO GetLessonById(int id);
        public List<LessonDTO> GetLessonByStudentId(int id);
        public List<LessonDTO> GetLessonsByTeacher(int id);
    }
}
