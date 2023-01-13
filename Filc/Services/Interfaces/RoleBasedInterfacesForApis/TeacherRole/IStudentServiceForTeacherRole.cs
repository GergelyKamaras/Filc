using Filc.Models.EntityViewModels.Student;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.TeacherRole
{
    public interface IStudentServiceForTeacherRole
    {
        public StudentDTO GetStudent(int id);

        public List<StudentDTO> GetStudentsbyTeacherId(int teacherId);
    }
}
