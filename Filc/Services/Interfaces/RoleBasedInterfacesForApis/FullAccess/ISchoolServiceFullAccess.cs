using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ISchoolServiceFullAccess : ISchoolServiceForParentRole, ISchoolServiceForStudentRole, ISchoolServiceForTeacherRole, ISchoolServiceForSchoolAdminRole
    {
        public new SchoolDTO GetSchool(int id);
        public List<SchoolDTO> GetAllSchools();
        public void AddSchool(School school);
        public void RemoveSchool(int id);
        public new void UpdateSchool(School school);
    }
}
