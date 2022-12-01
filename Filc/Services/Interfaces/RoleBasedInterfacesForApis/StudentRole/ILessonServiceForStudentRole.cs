using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Lesson;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface ILessonServiceForStudentRole
    {
        public LessonViewModel GetLessonById(int id);
        public List<LessonViewModel> GetLessonByStudentId(int id);
    }
}
