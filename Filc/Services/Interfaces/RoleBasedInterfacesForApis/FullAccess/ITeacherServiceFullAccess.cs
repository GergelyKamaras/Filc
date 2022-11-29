using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ITeacherServiceFullAccess : ITeacherServiceForTeacherRole
    {
        public List<Teacher> GetAllTeachers();
        public List<Teacher> GetAllTeachersBySchool(int schoolId);
        public void AddTeacher(Teacher teacher, string email);
        public void RemoveTeacher(int id);
    }
}
