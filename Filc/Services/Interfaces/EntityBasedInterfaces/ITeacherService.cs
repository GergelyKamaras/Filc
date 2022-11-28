using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ITeacherService : ITeacherRoleTeacherService
    {
        public void AddTeacher(Teacher teacher, string email);
        public void RemoveTeacher(int id);
    }
}
