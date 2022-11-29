using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
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
