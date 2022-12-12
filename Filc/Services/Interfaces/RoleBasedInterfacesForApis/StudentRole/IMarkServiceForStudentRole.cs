using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Mark;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface IMarkServiceForStudentRole
    {
        public MarkDTO GetMark(int id);
        public List<MarkDTO> GetMarksByStudent(int studentId);
    }
}
