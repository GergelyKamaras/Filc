using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.InputDTOs;
using Filc.Models.ViewModels.Parent;
using Filc.Models.ViewModels.Shared;
using NuGet.DependencyResolver;

namespace Filc.Services.ModelConverter
{
    public class InputDtoConverter : IInputDTOConverter
    {
        private ESContext _db;

        public InputDtoConverter(ESContext esContext)
        {
            _db = esContext;
        }

        public Mark ConvertDtoToMark(MarkInputDTO markInputDto)
        {
            Mark mark = new()
            {
                Grade = markInputDto.Grade,
                Description = markInputDto.Description,
                Date = markInputDto.Date,
                Teacher = _db.Teacher.First(t => t.Id == markInputDto.TeacherId),
                Student = _db.Student.First(s => s.Id == markInputDto.StudentId),
                Lesson = _db.Lesson.First(l => l.Id == markInputDto.LessonId),
                Subject = _db.Subject.First(s => s.Id == markInputDto.SubjectId)
            };
            if (markInputDto.Id != null)
            {
                mark.Id = (int)markInputDto.Id;
            }
            return mark;
        }

        public Lesson ConvertDtoToLesson(LessonInputDTO lessonInputDto)
        {
            Lesson lesson = new()
            {
                Name = lessonInputDto.Name,
                School = _db.School.First(s => s.Id == lessonInputDto.SchoolId),
                Subject = _db.Subject.First(s => s.Id == lessonInputDto.SubjectId),
                students = new List<Student>(),
                Teachers = new List<Teacher>()
            };
            if (lessonInputDto.Id != null)
            {
                lesson.Id = (int)lessonInputDto.Id;
            }
            return lesson;
        }

        public GovernmentAdmin ConvertDtoToGovernmentAdmin(GovernmentAdminInputDTO adminInputDto)
        {
            GovernmentAdmin admin = new()
            {
                user = adminInputDto.user
            };
            if (adminInputDto.Id != null)
            {
                admin.Id = (int)adminInputDto.Id;
            }
            return admin;
        }

        public School ConvertDtoToSchool(SchoolInputDTO schoolInputDto)
        {
            School school = new()
            {
                Name = schoolInputDto.Name,
                Address = schoolInputDto.Address,
                SchoolType = schoolInputDto.SchoolType,
                SchoolAdmin = new List<SchoolAdmin>(),
                Students = new List<Student>(),
                Subjects = new List<Subject>(),
                Lessons = new List<Lesson>(),
                Teachers = new List<Teacher>(),
                Classes = new List<SchoolClass>()
            };
            if (schoolInputDto.Id != null)
            {
                school.Id = (int)schoolInputDto.Id;
            }
            return school;

        }

        public Teacher ConvertDtoToTeacher(TeacherInputDTO teacherInputDto)
        {
            Teacher teacher = new()
            {
                user = teacherInputDto.user,
                FirstName = teacherInputDto.FirstName,
                LastName = teacherInputDto.LastName,
                BirthDate = teacherInputDto.BirthDate,
                Address = teacherInputDto.Address,
                Subjects = new List<Subject>(),
                Lessons = new List<Lesson>(),
                School = _db.School.First(s => s.Id == teacherInputDto.SchoolId),
            };
            if (teacherInputDto.Id != null)
            {
                teacher.Id = (int)teacherInputDto.Id;
            }
            return teacher;
        }

        public Student ConvertDtoToStudent(StudentInputDTO studentInputDto)
        {
            Student student = new()
            {
                user = studentInputDto.user,
                FirstName = studentInputDto.FirstName,
                LastName = studentInputDto.LastName,
                BirthDate = studentInputDto.BirthDate,
                Address = studentInputDto.Address,
                Lessons = new List<Lesson>(),
                School = _db.School.First(s => s.Id == studentInputDto.SchoolId),
                Marks = new List<Mark>(),
            };
            if (studentInputDto.Id != null)
            {
                student.Id = (int)studentInputDto.Id;
            }
            return student;
        }

        public Parent ConvertDtoToParent(ParentInputDTO parentInputDto)
        {
            Parent parent = new()
            {
                user = parentInputDto.user,
                Children = new List<Student>()
            };
            if (parentInputDto.Id != null)
            {
                parent.Id = (int)parentInputDto.Id;
            }
            return parent;
        }

        public SchoolAdmin ConvertDtoToSchoolAdmin(SchoolAdminInputDTO schoolAdminInputDto)
        {
            SchoolAdmin schoolAdmin = new()
            {
                user = schoolAdminInputDto.user,
                FirstName = schoolAdminInputDto.FirstName,
                LastName = schoolAdminInputDto.LastName,
                BirthDate = schoolAdminInputDto.BirthDate,
                Address = schoolAdminInputDto.Address,
                School = _db.School.First(s => s.Id == schoolAdminInputDto.SchoolId),
            };
            if (schoolAdminInputDto.Id != null)
            {
                schoolAdmin.Id = (int)schoolAdminInputDto.Id;
            }
            return schoolAdmin;
        }
    }
}
