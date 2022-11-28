using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IMarkService : IParentRoleMarkService, IStudentRoleMarkService
    {
        public void AddMark(Mark mark);
        public void UpdateMark(Mark mark);
        public void DeleteMark(int id);
        public List<Mark> GetMarkByLesson(int lessonId);
    }
}
