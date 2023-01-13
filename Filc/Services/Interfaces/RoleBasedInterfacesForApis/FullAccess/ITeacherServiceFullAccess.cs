using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.Teacher;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ITeacherServiceFullAccess : ITeacherServiceForTeacherRole
    {
        public List<TeacherDTO> GetAllTeachers();       
        public JWTAuthenticationResponse AddTeacher(Teacher teacher);
        public void RemoveTeacher(int id);
    }
}
