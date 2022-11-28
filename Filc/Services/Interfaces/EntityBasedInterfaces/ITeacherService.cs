using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ITeacherService : ITeacherRoleTeacherService
    {
        public List<Teacher> GetAllTeachers();
        public List<Teacher> GetAllTeachersBySchool(int schoolId);
        public void AddTeacher(Teacher teacher, string email);
        public void RemoveTeacher(int id);
    }
}
