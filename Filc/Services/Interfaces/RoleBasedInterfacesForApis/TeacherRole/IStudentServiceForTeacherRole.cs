using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface IStudentServiceForTeacherRole
    {
        public Student GetStudent(int id);
    }
}
