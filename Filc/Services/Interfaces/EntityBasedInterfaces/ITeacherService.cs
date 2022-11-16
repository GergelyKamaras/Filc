using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ITeacherService : ITeacherRoleTeacherService
    {
        public Teacher GetTeacher(int id);
        public void AddTeacher(Teacher teacher);
        public void UpdateTeacher(Teacher teacher);
        public void RemoveTeacher(int id);
    }
}
