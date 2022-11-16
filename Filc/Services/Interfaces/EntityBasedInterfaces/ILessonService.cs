using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.TeacherRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ILessonService : IParentRoleLessonService, IStudentRoleLessonService, ITeacherRoleLessonService
    {
        public Lesson GetLessonById(int id);
        public List<Lesson> GetLessonByStudentId(int id);
        public List<Lesson> GetLessonsByTeacher(int id);
        public void AddLesson(Lesson lesson);
        public void UpdateLesson(Lesson lesson);
        public void DeleteLesson(int id);
    }
}
