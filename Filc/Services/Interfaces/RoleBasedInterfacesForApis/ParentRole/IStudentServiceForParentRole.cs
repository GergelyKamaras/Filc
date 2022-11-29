using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole
{
    public interface IStudentServiceForParentRole
    {
        public Student GetStudent(int id);
        public void UpdateStudent(Student student);
    }
}
