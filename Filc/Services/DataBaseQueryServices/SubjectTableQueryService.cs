using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.Subject;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class SubjectTableQueryService : ISubjectServiceFullAccess
    {
        private ESContext _db;

        public SubjectTableQueryService(ESContext esContext)
        {
            _db = esContext;
        }

        public Subject GetSubject(int id)
        {
            Subject subject = _db.Subject.First(x => x.Id == id);
            return subject;
        }

        public JWTAuthenticationResponse AddSubject(Subject subject)
        {
            _db.Subject.Add(subject);
            _db.SaveChanges();
            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration successful!",
                Id = subject.Id
            };
        }

        public void UpdateSubject(Subject subject)
        {
            _db.Subject.Update(subject);
            _db.SaveChanges();
        }

        public void DeleteSubject(int id)
        {
            _db.Subject.Remove(_db.Subject.First(subject => subject.Id == id));
            _db.SaveChanges();
        }

        public List<SubjectDTO> GetSubjectsByStudent(int studentId)
        {
            var subjects = _db.Student.Where(s => s.Id == studentId).SelectMany(x => x.Lessons).Select(l => l.Subject)
                .ToList();
            return ModelConverter.ModelConverter.MapSubjectsToSubjectViewModels(subjects);
        }

        public Subject GetSubjectByLesson(int lessonId)
        {
            Subject subject = _db.Lesson.First(l => l.Id == lessonId).Subject;
            return subject;
        }
        public List<Subject> GetSubjectsBySchool(int schoolId)
        {
            var subjects = _db.School.Where(s => s.Id == schoolId).SelectMany(s => s.Subjects).ToList();
            return subjects;
        }
}
}
