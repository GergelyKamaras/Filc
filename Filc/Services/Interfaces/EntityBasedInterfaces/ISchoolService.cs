using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ISchoolService : IParentRoleSchoolService, IStudentRoleSchoolService, ITeacherRoleSchoolService
    {
        public School GetSchool(int id);
        public List<School> GetAllSchools();
        public void AddSchool(School school);
        public void RemoveSchool(int id);
        public void UpdateSchool(School school);
    }
}
