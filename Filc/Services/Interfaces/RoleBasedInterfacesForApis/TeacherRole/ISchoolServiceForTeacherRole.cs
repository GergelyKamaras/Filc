using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface ISchoolServiceForTeacherRole
    {
        public SchoolViewModel GetSchool(int id);
    }
}
