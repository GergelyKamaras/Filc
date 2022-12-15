using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
using Filc.Models.ViewModels.Lesson;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ILessonServiceFullAccess : ILessonServiceForParentRole, ILessonServiceForStudentRole, ILessonServiceForTeacherRole
    {
        public new LessonDTO GetLessonById(int id);
        public new List<LessonDTO> GetLessonByStudentId(int id);
        public JWTAuthenticationResponse AddLesson(Lesson lesson);
        public void UpdateLesson(Lesson lesson);
        public void DeleteLesson(int id);
    }
}
