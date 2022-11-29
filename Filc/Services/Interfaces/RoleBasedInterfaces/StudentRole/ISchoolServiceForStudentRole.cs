using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole
{
    public interface ISchoolServiceForStudentRole
    {
        public School GetSchool(int id);
    }
}
