using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface IStudentServiceForStudentRole
    {
        public Student GetStudent(int id);
        public void UpdateStudent(Student student);
    }
}
