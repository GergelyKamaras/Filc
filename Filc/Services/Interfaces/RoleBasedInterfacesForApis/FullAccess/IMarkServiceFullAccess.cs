using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Mark;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface IMarkServiceFullAccess : IMarkServiceForParentRole, IMarkServiceForStudentRole
    {
        public new MarkDTO GetMark(int id);
        public new List<MarkDTO> GetMarksByStudent(int studentId);
        public void AddMark(Mark mark);
        public void UpdateMark(Mark mark);
        public void DeleteMark(int id);
        public List<MarkDTO> GetMarkByLesson(int lessonId);
    }
}
