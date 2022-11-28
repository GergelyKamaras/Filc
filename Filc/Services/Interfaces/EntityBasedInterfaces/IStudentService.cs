using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IStudentService : IParentRoleStudentService, IStudentRoleStudentService, ITeacherRoleStudentService
    {
        public List<Student> GetAllStudents();
        public void AddStudent(Student student, string email);
        public void DeleteStudent(int id);
    }
}
