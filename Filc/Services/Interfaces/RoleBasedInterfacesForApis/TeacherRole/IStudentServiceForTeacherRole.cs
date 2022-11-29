using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole
{
    public interface IStudentServiceForTeacherRole
    {
        public Student GetStudent(int id);
    }
}
