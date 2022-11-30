using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface ISchoolServiceForStudentRole
    {
        public SchoolViewModel GetSchool(int id);
    }
}
