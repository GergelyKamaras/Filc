using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface ITeacherServiceForTeacherRole
    {
        public Teacher GetTeacher(int id);
        public void UpdateTeacher(Teacher teacher);
    }
}
