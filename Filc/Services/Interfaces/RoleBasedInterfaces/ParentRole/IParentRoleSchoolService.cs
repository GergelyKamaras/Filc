using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole
{
    public interface IParentRoleSchoolService
    {
        public School GetSchool(int id);
        public Parent GetParent(int id);
        public Student GetStudent(int id);
        public void UpdateParent(Parent parent);
        public void UpdateStudent(Student student);
        public List<Mark> GetMarksByStudent(int studentId);
        public List<Mark> GetMarksByLessonByStudent(int studentId, int lessonId);
    }
}
