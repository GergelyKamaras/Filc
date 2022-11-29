using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ILessonServiceFullAccess : ILessonServiceForParentRole, ILessonServiceForStudentRole, ILessonServiceForTeacherRole
    {
        public new Lesson GetLessonById(int id);
        public new List<Lesson> GetLessonByStudentId(int id);
        public void AddLesson(Lesson lesson);
        public void UpdateLesson(Lesson lesson);
        public void DeleteLesson(int id);
    }
}
