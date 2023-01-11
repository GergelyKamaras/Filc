using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Teacher;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface ITeacherServiceForTeacherRole
    {
        public TeacherDTO GetTeacher(int id);
        public List<TeacherDTO> GetAllTeachersBySchool(int schoolId);
        public void UpdateTeacher(Teacher teacher);
    }
}
