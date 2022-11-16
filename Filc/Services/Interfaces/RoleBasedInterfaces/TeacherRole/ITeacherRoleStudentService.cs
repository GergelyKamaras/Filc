using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole
{
    public interface ITeacherRoleStudentService
    {
        public Student GetStudent(int id);
    }
}
