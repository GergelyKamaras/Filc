using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Teacher;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ITeacherServiceFullAccess : ITeacherServiceForTeacherRole
    {
        public List<TeacherViewModel> GetAllTeachers();
        public List<TeacherViewModel> GetAllTeachersBySchool(int schoolId);
        public void AddTeacher(Teacher teacher);
        public void RemoveTeacher(int id);
    }
}
