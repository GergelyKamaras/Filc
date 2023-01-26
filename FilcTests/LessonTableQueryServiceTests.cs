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
                Subject = new Subject { Id = 1, Title = "Test"},
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
            Assert.That(result, Is.EqualTo(lessonDTO));
        }

        [Test]
        public void GetLessonById_NonExistentId_ThrowsException()
        {
            //Arrange

            //Act
            var exception = Assert.Catch<KeyNotFoundException>(()=> service.GetLessonById(1));

            //Assert
            Assert.IsNotNull(exception);
            Assert.That(exception.Message, Is.EqualTo("Lesson not found."));
        }

        [Test]
        public void GetLessonByStudentId_ExistingId_ReturnsListOfLessonDTO()
        {
            //Arrange
            var school = new School { Id = 1 };
            _InMemoryDb.School.Add(school);

            var subject = new Subject { Id = 1, Title = "Test" };

            var student = new Student
            {
                Id = 1,
                user = new ApplicationUser
                {
                    UserName = "student@test.com",
                    Salt = "testSalt",
                    Id = Guid.NewGuid().ToString()
        },
                FirstName = "John",
                LastName = "Test",
                Address = "123 Testy Lane",
                BirthDate = DateTime.Now,
                School = school
            };
            _InMemoryDb.Student.Add(student);

            var lesson1 = new Lesson
            {
                Id = 5,
                Name = "Test",
                Subject = subject,
                students = new List<Student> { student },
                Teachers = new List<Teacher>(),
                School = school
            };

            var lesson2 = new Lesson
            {
                Id = 6,
                Name = "Test2",
                Subject = subject,
                students = new List<Student> { student },
                Teachers = new List<Teacher>(),
                School = school
            };

            var lesson3 = new Lesson
            {
                Id = 7,
                Name = "Test3",
                Subject = subject,
                students = new List<Student> { student },
                Teachers = new List<Teacher>(),
                School = school
            };
            _InMemoryDb.Lesson.Add(lesson1);
            _InMemoryDb.Lesson.Add(lesson2);
            _InMemoryDb.Lesson.Add(lesson3);
            _InMemoryDb.SaveChanges();

            List<LessonDTO> TestLessons = new List<LessonDTO> { 
                new LessonDTO(lesson1),
                new LessonDTO(lesson2),
                new LessonDTO(lesson3)};

            //Act
            List<LessonDTO> lessons = service.GetLessonByStudentId(1);

            //Assert
            Assert.That(lessons,Is.EquivalentTo(TestLessons));
        }
    }
}
