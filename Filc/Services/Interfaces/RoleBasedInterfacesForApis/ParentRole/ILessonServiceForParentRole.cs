using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole
{
    public interface ILessonServiceForParentRole
    {
        public List<Lesson> GetLessonByStudentId(int id);
    }
}
