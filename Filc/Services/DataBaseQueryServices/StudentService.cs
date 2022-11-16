using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;

namespace Filc.Services.DataBaseQueryServices
{
    public class StudentService : IStudentService
    {
        private ESContext _db;
        public StudentService(ESContext esContext)
        {
            _db = esContext;
        }
        public Student GetStudent(int id)
        {
            return _db.Student.First(x => x.Id == id);
        }

        public List<Student> GetAllStudents()
        {
            return _db.Student.ToList();
        }

        public void AddStudent(Student student)
        {
            _db.Student.Add(student);
            _db.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _db.Student.Update(student);
            _db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            _db.Student.Remove(_db.Student.First(student => student.Id == id));
            _db.SaveChanges();
        }
    }
}
