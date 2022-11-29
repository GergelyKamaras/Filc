using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ISchoolServiceFullAccess : ISchoolServiceForParentRole, ISchoolServiceForStudentRole, ISchoolServiceForTeacherRole, ISchoolServiceForSchoolAdminRole
    {
        public new School GetSchool(int id);
        public List<School> GetAllSchools();
        public void AddSchool(School school);
        public void RemoveSchool(int id);
        public new void UpdateSchool(School school);
    }
}
