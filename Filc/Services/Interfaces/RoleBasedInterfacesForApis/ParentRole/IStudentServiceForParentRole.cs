using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Student;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole
{
    public interface IStudentServiceForParentRole
    {
        public StudentDTO GetStudent(int id);
        public void UpdateStudent(Student student);
    }
}
