using Assert = NUnit.Framework.Assert;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Microsoft.EntityFrameworkCore;
using Filc.Models.ViewModels.Lesson;

namespace FilcTests
{
    [TestFixture]
    public class LessonTableQueryServiceTests
    {
        public ESContext _InMemoryDb;
        public LessonTableQueryService service;

        [SetUp]
        public void Setup()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<ESContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;
            _InMemoryDb = new ESContext(options);

            service = new LessonTableQueryService(_InMemoryDb);
        }

        [Test]
        public void GetLessonById_ExistingId_ReturnsLessonDTO()
        {
            //Arrange
            var lesson = new Lesson
            {
                Id = 1,
                Name = "Test",
                Subject = new Subject { Id = 1, Title = "Test" },
                students = new List<Student>(),
                Teachers = new List<Teacher>(),
                School = new School { Id = 1 }
            };
            _InMemoryDb.Lesson.Add(lesson);
            _InMemoryDb.SaveChanges();

            var lessonDTO = new LessonDTO(lesson);

            //Act
            LessonDTO result = service.GetLessonById(1);

            //Assert
            Assert.That(result.Id, Is.EqualTo(lessonDTO.Id));
        }

        [Test]
        public void GetLessonById_NonExistentId_ThrowsException()
        {
            //Arrange

            //Act
            var exception = Assert.Catch<KeyNotFoundException>(() => service.GetLessonById(1));

            //Assert
            Assert.IsNotNull(exception);
            Assert.That(exception.Message, Is.EqualTo("Lesson not found."));
        }

        //[Test]
        //public void GetLessonByStudentId_ExistingId_ReturnsListOfLessonDTO()
        //{
        //    //Arrange
        //    var school = new School { Id = 1 };
        //    _InMemoryDb.School.Add(school);

        //    var subject = new Subject { Id = 1, Title = "Test" };
        //    _InMemoryDb.Subject.Add(subject);

        //    var student = new Student
        //    {
        //        Id = 1,
        //        user = new ApplicationUser
        //        {
        //            UserName = "student@test.com",
        //            Salt = "testSalt",
        //            Id = Guid.NewGuid().ToString()
        //        },
        //        FirstName = "John",
        //        LastName = "Test",
        //        Address = "123 Testy Lane",
        //        BirthDate = DateTime.Now,
        //        School = school
        //    };
        //    _InMemoryDb.Student.Add(student);

        //    var lesson1 = new Lesson
        //    {
        //        Id = 5,
        //        Name = "Test",
        //        Subject = subject,
        //        students = new List<Student> { student },
        //        Teachers = new List<Teacher>(),
        //        School = school
        //    };

        //    var lesson2 = new Lesson
        //    {
        //        Id = 6,
        //        Name = "Test2",
        //        Subject = subject,
        //        students = new List<Student> { student },
        //        Teachers = new List<Teacher>(),
        //        School = school
        //    };

        //    var lesson3 = new Lesson
        //    {
        //        Id = 7,
        //        Name = "Test3",
        //        Subject = subject,
        //        students = new List<Student> { student },
        //        Teachers = new List<Teacher>(),
        //        School = school
        //    };
        //    _InMemoryDb.Lesson.Add(lesson1);
        //    _InMemoryDb.Lesson.Add(lesson2);
        //    _InMemoryDb.Lesson.Add(lesson3);
        //    _InMemoryDb.SaveChanges();

        //    //Act
        //    List<LessonDTO> lessons = service.GetLessonByStudentId(1);
        //    var count = lessons.Count;

        //    //Assert
        //    Assert.That(count, Is.EqualTo(3));
        //    Assert.That(lessons[0], Is.InstanceOf<LessonDTO>());
        //}

        //[Test]
        //public void GetLessonByStudentId_NonExistent_ReturnsEmptyList()
        //{
        //    //Arrange
        //    var school = new School { Id = 1 };
        //    _InMemoryDb.School.Add(school);

        //    var subject = new Subject { Id = 2, Title = "Test" };
        //    _InMemoryDb.Subject.Add(subject);

        //    var student = new Student
        //    {
        //        Id = 3,
        //        user = new ApplicationUser
        //        {
        //            UserName = "student@test.com",
        //            Salt = "testSalt",
        //            Id = Guid.NewGuid().ToString()
        //        },
        //        FirstName = "John",
        //        LastName = "Test",
        //        Address = "123 Testy Lane",
        //        BirthDate = DateTime.Now,
        //        School = school
        //    };
        //    _InMemoryDb.Student.Add(student);

        //    var lesson1 = new Lesson
        //    {
        //        Id = 5,
        //        Name = "Test",
        //        Subject = subject,
        //        students = new List<Student> { student },
        //        Teachers = new List<Teacher>(),
        //        School = school
        //    };

        //    var lesson2 = new Lesson
        //    {
        //        Id = 6,
        //        Name = "Test2",
        //        Subject = subject,
        //        students = new List<Student> { student },
        //        Teachers = new List<Teacher>(),
        //        School = school
        //    };

        //    var lesson3 = new Lesson
        //    {
        //        Id = 7,
        //        Name = "Test3",
        //        Subject = subject,
        //        students = new List<Student> { student },
        //        Teachers = new List<Teacher>(),
        //        School = school
        //    };
        //    _InMemoryDb.Lesson.Add(lesson1);
        //    _InMemoryDb.Lesson.Add(lesson2);
        //    _InMemoryDb.Lesson.Add(lesson3);
        //    _InMemoryDb.SaveChanges();

        //    //Act
        //    List<LessonDTO> lessons = service.GetLessonByStudentId(2);

        //    //Assert
        //    var count = lessons.Count();
        //    Assert.That(count, Is.EqualTo(0));
        //}

        //[Test]
        //public void GetLessonsByTeacher_ExistingID_returnsLessons()
        //{
        //    //Arrange
        //    var school = new School
        //    {
        //        Id = 10
        //    };
        //    _InMemoryDb.School.Add(school);
        //    _InMemoryDb.SaveChanges();

        //    var teacher = new Teacher
        //    {
        //        Id = 1,
        //        user = new ApplicationUser
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Salt = "randomtestsalt",
        //            UserName = "testteacher@test.com"
        //        },
        //        FirstName = "Test",
        //        LastName = "Testy",
        //        Address = "456 Teacher Street TeachyTown",
        //        BirthDate = DateTime.Now,
        //        School = school
        //    };
        //    _InMemoryDb.Teacher.Add(teacher);
        //    _InMemoryDb.SaveChanges();

        //    var subject = new Subject
        //    {
        //        Id = 11,
        //        Title = "Test Studies"
        //    };
        //    _InMemoryDb.Subject.Add(subject);
        //    _InMemoryDb.SaveChanges();

        //    var lesson1 = new Lesson
        //    {
        //        Id = 12,
        //        Name = "Test lesson",
        //        School = school,
        //        Subject = subject,
        //        Teachers = new List<Teacher> { teacher },
        //        students = new List<Student>()
        //    };

        //    var lesson2 = new Lesson
        //    {
        //        Id = 13,
        //        Name = "Test lesson2",
        //        School = school,
        //        Subject = subject,
        //        Teachers = new List<Teacher> { teacher },
        //        students = new List<Student>()
        //    };
        //    _InMemoryDb.Lesson.Add(lesson1);
        //    _InMemoryDb.Lesson.Add(lesson2);
        //    _InMemoryDb.SaveChanges();

        //    //Act
        //    List<LessonDTO> lessons = service.GetLessonsByTeacher(1);

        //    //Assert
        //    var count = lessons.Count();
        //    Assert.That(count, Is.EqualTo(2));
        //}

        //[Test]
        //public void GetLessonsByTeacher_NonExistentID_returnsEmptyList()
        //{
        //    //Arrange
        //    var school = new School
        //    {
        //        Id = 10
        //    };
        //    _InMemoryDb.School.Add(school);
        //    _InMemoryDb.SaveChanges();

        //    var teacher = new Teacher
        //    {
        //        Id = 1,
        //        user = new ApplicationUser
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Salt = "randomtestsalt",
        //            UserName = "testteacher@test.com"
        //        },
        //        FirstName = "Test",
        //        LastName = "Testy",
        //        Address = "456 Teacher Street TeachyTown",
        //        BirthDate = DateTime.Now,
        //        School = school
        //    };
        //    _InMemoryDb.Teacher.Add(teacher);
        //    _InMemoryDb.SaveChanges();

        //    var subject = new Subject
        //    {
        //        Id = 11,
        //        Title = "Test Studies"
        //    };
        //    _InMemoryDb.Subject.Add(subject);
        //    _InMemoryDb.SaveChanges();

        //    var lesson1 = new Lesson
        //    {
        //        Id = 12,
        //        Name = "Test lesson",
        //        School = school,
        //        Subject = subject,
        //        Teachers = new List<Teacher> { teacher },
        //        students = new List<Student>()
        //    };

        //    var lesson2 = new Lesson
        //    {
        //        Id = 13,
        //        Name = "Test lesson2",
        //        School = school,
        //        Subject = subject,
        //        Teachers = new List<Teacher> { teacher },
        //        students = new List<Student>()
        //    };
        //    _InMemoryDb.Lesson.Add(lesson1);
        //    _InMemoryDb.Lesson.Add(lesson2);
        //    _InMemoryDb.SaveChanges();

        //    //Act
        //    List<LessonDTO> lessons = service.GetLessonsByTeacher(2);

        //    //Assert
        //    var count = lessons.Count();
        //    Assert.That(count, Is.EqualTo(0));
        //}

        [Test]
        public void AddLesson_NewLesson_AddsLessonReturnsSuccessMessage()
        {
            //Arrange
            var school = new School
            {
                Id = 11
            };
            _InMemoryDb.School.Add(school);
            _InMemoryDb.SaveChanges();

            var subject = new Subject
            {
                Id = 12,
                Title = "TestSubject"
            };
            _InMemoryDb.Subject.Add(subject);
            _InMemoryDb.SaveChanges();

            var lesson = new Lesson
            {
                Id = 21,
                Name = "ThisLesson",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher>() { }
            };
            _InMemoryDb.SaveChanges();

            //Act
            var response = service.AddLesson(lesson);

            //Assert
            var data = _InMemoryDb.Lesson.FirstOrDefault(x => x.Id == lesson.Id);
            Assert.IsNotNull(data);
            Assert.That(data, Is.EqualTo(lesson));
            Assert.That(response.Status, Is.EqualTo("Success"));
        }

        [Test]
        public void AddLesson_ExistingLesson_ThrowsArgumentException()
        {
            //Arrange
            var school = new School
            {
                Id = 11
            };
            _InMemoryDb.School.Add(school);
            _InMemoryDb.SaveChanges();

            var subject = new Subject
            {
                Id = 12,
                Title = "TestSubject"
            };
            _InMemoryDb.Subject.Add(subject);
            _InMemoryDb.SaveChanges();

            var lesson = new Lesson
            {
                Id = 21,
                Name = "ThisLesson",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher>() { }
            };
            _InMemoryDb.Lesson.Add(lesson);
            _InMemoryDb.SaveChanges();

            //Act
            var exception = Assert.Catch<ArgumentException>(() => service.AddLesson(lesson));

            //Assert
            Assert.That(exception.Message, Is.EqualTo("An item with the same key has already been added. Key: 21"));
        }

        [Test]
        public void UpdateLesson_ExistingLesson_UpdatesLesson()
        {
            //Arrange
            var school = new School
            {
                Id = 11
            };
            _InMemoryDb.School.Add(school);
            _InMemoryDb.SaveChanges();

            var subject = new Subject
            {
                Id = 12,
                Title = "TestSubject"
            };
            _InMemoryDb.Subject.Add(subject);
            _InMemoryDb.SaveChanges();

            var lesson = new Lesson
            {
                Id = 21,
                Name = "ThisLesson",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher>() { }
            };
            _InMemoryDb.Lesson.Add(lesson);
            _InMemoryDb.SaveChanges();

            lesson.Name = "UpdatedLesson";

            //Act
            service.UpdateLesson(lesson);

            //Assert
            var updatedLesson = _InMemoryDb.Lesson.FirstOrDefault(l => l.Id == lesson.Id);
            Assert.IsNotNull(updatedLesson);
            Assert.That(updatedLesson.Name, Is.EqualTo("UpdatedLesson"));
        }

        [Test]
        public void UpdateLesson_NonExistentLesson_DoesntUpdate()
        {
            //Arrange
            var school = new School
            {
                Id = 11
            };
            _InMemoryDb.School.Add(school);
            _InMemoryDb.SaveChanges();

            var subject = new Subject
            {
                Id = 12,
                Title = "TestSubject"
            };
            _InMemoryDb.Subject.Add(subject);
            _InMemoryDb.SaveChanges();

            var lesson = new Lesson
            {
                Id = 21,
                Name = "ThisLesson",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher>() { }
            };
            _InMemoryDb.Lesson.Add(lesson);
            _InMemoryDb.SaveChanges();

            var lesson2 = new Lesson
            {
                Id = 22,
                Name = "UpdatedLesson",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher>() { }
            };

            //Act
            var exception = Assert.Catch<DbUpdateConcurrencyException>(() => service.UpdateLesson(lesson2));

            //Assert
            Assert.IsNotNull(exception);
            Assert.That(exception.Message, Is.EqualTo("Attempted to update or delete an entity that does not exist in the store."));
        }

        [Test]
        public void DeleteLesson_ExistingId_DeletesLesson()
        {
            //Arrange
            var school = new School
            {
                Id = 11
            };
            _InMemoryDb.School.Add(school);
            _InMemoryDb.SaveChanges();

            var subject = new Subject
            {
                Id = 12,
                Title = "TestSubject"
            };
            _InMemoryDb.Subject.Add(subject);
            _InMemoryDb.SaveChanges();

            var lesson = new Lesson
            {
                Id = 21,
                Name = "ThisLesson",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher>() { }
            };
            _InMemoryDb.Lesson.Add(lesson);
            _InMemoryDb.SaveChanges();

            //Act
            service.DeleteLesson(lesson.Id);

            //Assert
            var count = _InMemoryDb.Lesson.Count();
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void DeleteLesson_NonExistentId_DoesntDeleteLesson()
        {
            //Arrange
            var school = new School
            {
                Id = 11
            };
            _InMemoryDb.School.Add(school);
            _InMemoryDb.SaveChanges();

            var subject = new Subject
            {
                Id = 12,
                Title = "TestSubject"
            };
            _InMemoryDb.Subject.Add(subject);
            _InMemoryDb.SaveChanges();

            var lesson = new Lesson
            {
                Id = 21,
                Name = "ThisLesson",
                School = school,
                students = new List<Student>(),
                Subject = subject,
                Teachers = new List<Teacher>() { }
            };
            _InMemoryDb.Lesson.Add(lesson);
            _InMemoryDb.SaveChanges();

            //Act
            service.DeleteLesson(2);

            //Assert
            var count = _InMemoryDb.Lesson.Count();
            Assert.That(count, Is.EqualTo(1));
        }
    }
}
