using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Mark;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole
{
    public interface IMarkServiceForParentRole
    {
        public MarkDTO GetMark(int id);
        public List<MarkDTO> GetMarksByStudent(int studentId);
    }
}
