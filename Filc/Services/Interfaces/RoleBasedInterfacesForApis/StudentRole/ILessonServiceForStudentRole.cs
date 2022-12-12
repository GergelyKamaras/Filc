using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Lesson;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface ILessonServiceForStudentRole
    {
        public LessonDTO GetLessonById(int id);
        public List<LessonDTO> GetLessonByStudentId(int id);
    }
}
