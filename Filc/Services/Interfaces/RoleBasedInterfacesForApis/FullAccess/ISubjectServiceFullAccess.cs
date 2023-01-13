using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.EntityViewModels.Subject;
using Filc.Models.InputDTOs;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.SchoolAdminRole;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface ISubjectServiceFullAccess : ISubjectServiceForSchoolAdminRole, ISubjectServiceForStudentRole
    {
        public Subject GetSubject(int id);
        public List<SubjectDTO> GetSubjectsByStudent(int studentId);
        public JWTAuthenticationResponse AddSubject(Subject subject);
        public void UpdateSubject(Subject subject);
        public void DeleteSubject(int id);
        public Subject GetSubjectByLesson(int lessonId);
        public List<Subject> GetSubjectsBySchool(int schoolId);
    }
}
