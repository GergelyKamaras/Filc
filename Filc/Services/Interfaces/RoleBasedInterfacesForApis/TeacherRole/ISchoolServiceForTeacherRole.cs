using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface ISchoolServiceForTeacherRole
    {
        public School GetSchool(int id);
    }
}
