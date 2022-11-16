using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole
{
    public interface IStudentRoleMarkService
    {
        public Mark GeMark(int id);
        public List<Mark> GetMarksByStudent(int studentId);
        public List<Mark> GetMarksByLessonByStudent(int studentId, int lessonId);
    }
}
