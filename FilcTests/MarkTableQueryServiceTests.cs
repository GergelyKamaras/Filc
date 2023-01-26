using Assert = NUnit.Framework.Assert;
using NSubstitute;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Microsoft.EntityFrameworkCore;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.Models.ViewModels.Mark;

namespace FilcTests
{
    [TestFixture]
    public class MarkTableQueryServiceTests
    {
        public ESContext _InMemoryDb;
        public MarkTableQueryService service;

        [SetUp]
        public void SetUp()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<ESContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;
            _InMemoryDb = new ESContext(options);

            service = new MarkTableQueryService(_InMemoryDb);
        }

        [Test]
        public void GetMark_ExistingId_ReturnsMarkDTO()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);
            _InMemoryDb.SaveChanges();

            var markDTO = new MarkDTO(mark);

            //Act
            var result = service.GetMark(1);

            //Assert
            Assert.That(result.Id, Is.EqualTo(markDTO.Id));
        }

        [Test]
        public void GetMark_NonExistentId_ThrowsError()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);
            _InMemoryDb.SaveChanges();

            var markDTO = new MarkDTO(mark);

            //Act
            var exception = Assert.Catch<InvalidOperationException>(() => service.GetMark(2));

            //Assert
            Assert.That(exception.Message, Is.EqualTo("Sequence contains no elements"));
        }

        [Test]
        public void AddMark_NewMark_AddsMarkReturnsSuccess()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.SaveChanges();

            //Act
            var response = service.AddMark(mark);

            //Assert
            var data = _InMemoryDb.Mark.FirstOrDefault(x => x.Id == mark.Id);
            Assert.IsNotNull(data);
            Assert.That(data, Is.EqualTo(mark));
            Assert.That(response.Status, Is.EqualTo("Success"));
        }

        [Test]
        public void AddMark_ExistingMark_DoesntAddMarkThrowsError()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);
            _InMemoryDb.SaveChanges();

            //Act //Assert
            var exception = Assert.Catch<ArgumentException>(() => service.AddMark(mark));
        }

        [Test]
        public void UpdateMark_ExistingMark_UpdatesMark()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);
            _InMemoryDb.SaveChanges();

            mark.Description = "Updated Geometry pop quiz";

            //Act
            service.UpdateMark(mark);

            //Assert
            var data = _InMemoryDb.Mark.FirstOrDefault(m => m.Id == mark.Id);
            Assert.IsNotNull(data);
            Assert.That(data.Description, Is.EqualTo(mark.Description));
        }

        [Test]
        public void UpdateMark_NonExistentMark_ThrowsError()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);
            _InMemoryDb.SaveChanges();

            var mark2 = new Mark
            {
                Id = 2,
                Date = DateTime.Now,
                Description = "FakeMark",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)5,
                Student = student,
            };

            //Act //Assert
            var exception = Assert.Catch<DbUpdateConcurrencyException>(() => service.UpdateMark(mark2));
        }

        [Test]
        public void DeleteMark_ExistingMark_DeletesMark()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);
            _InMemoryDb.SaveChanges();

            //Act
            service.DeleteMark(1);

            //Assert
            var count = _InMemoryDb.Mark.Count();
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void DeleteMark_NonExistentMark_ThrowsError()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);
            _InMemoryDb.SaveChanges();

            var mark2 = new Mark
            {
                Id = 2,
                Date = DateTime.Now,
                Description = "FakeMark",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)5,
                Student = student,
            };

            //Act //Assert
            var exception = Assert.Catch<InvalidOperationException>(() => service.DeleteMark(mark2.Id));
        }

        [Test]
        public void GetMarksByStudent_ExistingStudentId_ReturnsMarkDTOList()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);


            var mark2 = new Mark
            {
                Id = 2,
                Date = DateTime.Now,
                Description = "FakeMark",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark2);
            _InMemoryDb.SaveChanges();

            //Act 
            List<MarkDTO> marks = service.GetMarksByStudent(6);

            //Assert
            Assert.IsNotNull(marks);
            Assert.That(marks, Has.Count.EqualTo(2));
            Assert.That(marks[0], Is.InstanceOf<MarkDTO>());
        }

        [Test]
        public void GetMarksByStudent_NonExistentStudentId_ThrowsError()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);
            _InMemoryDb.SaveChanges();

            var mark2 = new Mark
            {
                Id = 2,
                Date = DateTime.Now,
                Description = "FakeMark",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)5,
                Student = student,
            };

            //Act //Assert
            var exception = Assert.Catch<Exception>(() => service.GetMarksByStudent(55));
            Assert.That(exception.Message, Is.EqualTo("Student ID not found."));
        }

        [Test]
        public void GetMarksByStudent_ExistingStudentNoMarks_ReturnsEmptyMarkDTOList()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);
            _InMemoryDb.SaveChanges();

            //Act 
            List<MarkDTO> marks = service.GetMarksByStudent(6);

            //Assert
            Assert.That(marks.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetMarkByLesson_ExistingLesson_ReturnsMarkDTOList()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);

            var mark2 = new Mark
            {
                Id = 2,
                Date = DateTime.Now,
                Description = "FakeMark",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark2);
            _InMemoryDb.SaveChanges();

            //Act 
            List<MarkDTO> marks = service.GetMarkByLesson(5);

            //Assert
            Assert.That(marks, Is.Not.Null);
            Assert.That(marks, Has.Count.EqualTo(2));
        }

        [Test]
        public void GetMarkByLesson_NonExistentLesson_ThrowsError()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);

            var mark = new Mark
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Geometry pop quiz",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)4.5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark);

            var mark2 = new Mark
            {
                Id = 2,
                Date = DateTime.Now,
                Description = "FakeMark",
                Teacher = teacher,
                Subject = subject,
                Lesson = lesson,
                Grade = (float)5,
                Student = student,
            };
            _InMemoryDb.Mark.Add(mark2);
            _InMemoryDb.SaveChanges();

            //Act //Assert
            var exception = Assert.Catch<Exception>(() => service.GetMarkByLesson(6));
            Assert.That(exception.Message, Is.EqualTo("Lesson ID not found."));
        }

        [Test]
        public void GetMarkByLesson_ExistingLessonNoMarks_ReturnsEmptyMarkDTOList()
        {
            //Arrange
            var school = new School { Id = 3 };
            _InMemoryDb.School.Add(school);
            var subject = new Subject
            {
                Id = 4,
                Title = "Test"
            };
            _InMemoryDb.Subject.Add(subject);

            var student = new Student
            {
                Id = 6,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Test",
                    Salt = "testsalt"
                },
                Address = "Test Lane",
                FirstName = "Mark",
                LastName = "Test"
            };
            _InMemoryDb.Student.Add(student);

            var teacher = new Teacher
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testsalt",
                    UserName = "teacher@test.com"
                },
                FirstName = "Test",
                LastName = "Test",
                Address = "444 Teacher Street",
                School = school
            };
            _InMemoryDb.Teacher.Add(teacher);

            var lesson = new Lesson
            {
                Id = 5,
                Name = "Test",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher> { teacher }
            };
            _InMemoryDb.Lesson.Add(lesson);
            _InMemoryDb.SaveChanges();

            //Act 
            List<MarkDTO> marks = service.GetMarkByLesson(5);

            //Assert
            Assert.That(marks.Count, Is.EqualTo(0));
        }
    }
}
