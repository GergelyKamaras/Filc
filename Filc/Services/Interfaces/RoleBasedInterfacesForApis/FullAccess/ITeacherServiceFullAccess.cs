using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
using Filc.Models.ViewModels.Teacher;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ITeacherServiceFullAccess : ITeacherServiceForTeacherRole
    {
        public List<TeacherDTO> GetAllTeachers();
        public List<TeacherDTO> GetAllTeachersBySchool(int schoolId);
        public JWTAuthenticationResponse AddTeacher(Teacher teacher);
        public void RemoveTeacher(int id);
    }
}
