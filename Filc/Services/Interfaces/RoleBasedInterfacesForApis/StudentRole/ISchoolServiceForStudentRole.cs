using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface ISchoolServiceForStudentRole
    {
        public School GetSchool(int id);
    }
}
