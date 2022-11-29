using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface IMarkServiceForStudentRole
    {
        public Mark GetMark(int id);
        public List<Mark> GetMarksByStudent(int studentId);
    }
}
