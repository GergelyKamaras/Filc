using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole
{
    public interface IParentRoleMarkService
    {
        public Mark GetMark(int id);
        public List<Mark> GetMarksByStudent(int studentId);
        public List<Mark> GetMarksByLessonByStudent(int studentId, int lessonId);
    }
}
