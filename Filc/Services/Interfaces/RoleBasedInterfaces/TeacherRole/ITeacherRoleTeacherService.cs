using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole
{
    public interface ITeacherRoleTeacherService
    {
        public Teacher GetTeacher(int id);
        public void UpdateTeacher(Teacher teacher);
    }
}
