using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole
{
    public interface ITeacherRoleSchoolService
    {
        public School GetSchool(int id);
    }
}
