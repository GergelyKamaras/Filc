using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Lesson;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole
{
    public interface ILessonServiceForParentRole
    {
        public List<LessonViewModel> GetLessonByStudentId(int id);
    }
}
