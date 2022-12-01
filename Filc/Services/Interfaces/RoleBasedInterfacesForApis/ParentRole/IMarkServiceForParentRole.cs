using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Mark;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole
{
    public interface IMarkServiceForParentRole
    {
        public MarkViewModel GetMark(int id);
        public List<MarkViewModel> GetMarksByStudent(int studentId);
    }
}
