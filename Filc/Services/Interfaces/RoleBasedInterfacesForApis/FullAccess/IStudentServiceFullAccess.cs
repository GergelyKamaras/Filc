using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.Student;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface IStudentServiceFullAccess : IStudentServiceForParentRole, IStudentServiceForStudentRole, IStudentServiceForTeacherRole
    {
        public new StudentDTO GetStudent(int id);
        public new void UpdateStudent(Student student);
        public List<StudentDTO> GetAllStudents();
        public JWTAuthenticationResponse AddStudent(Student student);
        public void DeleteStudent(int id);
    }
}
