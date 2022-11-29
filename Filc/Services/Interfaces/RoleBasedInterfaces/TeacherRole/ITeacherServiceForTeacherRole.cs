using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole
{
    public interface ITeacherServiceForTeacherRole
    {
        public Teacher GetTeacher(int id);
        public void UpdateTeacher(Teacher teacher);
    }
}
