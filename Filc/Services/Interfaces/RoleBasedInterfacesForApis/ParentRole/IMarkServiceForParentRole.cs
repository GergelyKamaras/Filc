using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole
{
    public interface IMarkServiceForParentRole
    {
        public Mark GetMark(int id);
        public List<Mark> GetMarksByStudent(int studentId);
    }
}
