using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole
{
    public interface ISchoolServiceForParentRole
    {
        public SchoolViewModel GetSchool(int id);
    }
}
