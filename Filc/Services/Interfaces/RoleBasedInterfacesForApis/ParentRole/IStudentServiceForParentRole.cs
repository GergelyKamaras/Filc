using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole
{
    public interface IStudentServiceForParentRole
    {
        public Student GetStudent(int id);
        public void UpdateStudent(Student student);
    }
}
