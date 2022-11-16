using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole
{
    public interface IParentRoleLessonService
    {
        public List<Lesson> GetLessonByStudentId(int id);
    }
}
