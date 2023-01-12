using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.Subject;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.StudentRole
{
    public interface ISubjectServiceForStudentRole
    {
        public Subject GetSubject(int id);
        public List<SubjectDTO> GetSubjectsByStudent(int studentId);

        public List<Subject> GetSubjectsBySchool(int schoolId);
    }
}

