using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IStudentServiceFullAccess : IStudentServiceForParentRole, IStudentServiceForStudentRole, IStudentServiceForTeacherRole
    {
        public new Student GetStudent(int id);
        public new void UpdateStudent(Student student);
        public List<Student> GetAllStudents();
        public void AddStudent(Student student);
        public void DeleteStudent(int id);
    }
}
