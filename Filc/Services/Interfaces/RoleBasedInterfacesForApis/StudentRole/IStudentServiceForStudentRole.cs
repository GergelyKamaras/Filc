using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.Student;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface IStudentServiceForStudentRole
    {
        public StudentDTO GetStudent(int id);
        public void UpdateStudent(Student student);
    }
}
