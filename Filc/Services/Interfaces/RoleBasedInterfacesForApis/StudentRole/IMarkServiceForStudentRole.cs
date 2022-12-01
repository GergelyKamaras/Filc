using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Mark;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface IMarkServiceForStudentRole
    {
        public MarkViewModel GetMark(int id);
        public List<MarkViewModel> GetMarksByStudent(int studentId);
    }
}
