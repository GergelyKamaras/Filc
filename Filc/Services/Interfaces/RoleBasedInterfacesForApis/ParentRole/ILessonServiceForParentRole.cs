using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole
{
    public interface ILessonServiceForParentRole
    {
        public List<Lesson> GetLessonByStudentId(int id);
    }
}
