using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole
{
    public interface ISchoolServiceForTeacherRole
    {
        public School GetSchool(int id);
    }
}
