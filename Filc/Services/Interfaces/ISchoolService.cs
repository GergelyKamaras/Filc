using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.ModelInterfaces;


namespace Filc.Services.Interfaces
{
    // Services should be accessed only by SchoolAdmins
    public interface ISchoolService
    {
        public void RegisterTeacher(Teacher teacher, int schoolId);
        public void RegisterStudent(Student student, int schoolId);
        public void DeleteUser(string userRole, int id);
        public void UpdateUser(IUser user);
        public void UpdateLesson(int lessonId);
        public void AddStudentToClass(int StudentId, int ClassId);
        public void CreateLesson();
    }
}
