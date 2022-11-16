using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole
{
    public interface IParentRoleMarkService
    {
        public Mark GeMark(int id);
        public List<Mark> GetMarksByStudent(int studentId);
        public List<Mark> GetMarksByLessonByStudent(int studentId, int lessonId);
    }
}
