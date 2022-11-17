using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IStudentService : IParentRoleStudentService, IStudentRoleStudentService, ITeacherRoleStudentService
    {
        public Student GetStudent(int id);
        public List<Student> GetAllStudents();
        public void AddStudent(Student student, string email);
        public void UpdateStudent(Student student);
        public void DeleteStudent(int id);
    }
}
