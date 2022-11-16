using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole
{
    public interface IStudentRoleSchoolService
    {
        public School GetSchool(int id);
    }
}
