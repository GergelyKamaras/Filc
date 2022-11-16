using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ITeacherService
    {
        public Teacher GetTeacher(int id);
        public void AddTeacher(Teacher teacher);
        public void UpdateTeacher(Teacher teacher);
        public void RemoveTeacher(int id);
    }
}
