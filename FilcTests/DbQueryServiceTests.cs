using Assert = NUnit.Framework.Assert;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Microsoft.EntityFrameworkCore;

namespace FilcTests
{
    [TestFixture]
    public class DBModelServiceTests
    {
        public ESContext _InMemoryDb;
        public DBModelService service;

        [SetUp]
        public void Setup()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<ESContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;
            _InMemoryDb = new ESContext(options);

           service = new DBModelService(_InMemoryDb);
        }

        [Test]
        public void GetSchoolById_ReturnsCorrectSchool()
        {
            // Arrange
            var school = new School { Id = 1, Name = "Test School" };
            _InMemoryDb.School.Add(school);
            _InMemoryDb.SaveChanges();

            // Act
            var result = service.GetSchoolById(1);

            // Assert
            Assert.That(result, Is.EqualTo(school));
        }

        [Test]
        public void SchoolNameExists_ReturnsTrueIfNameExists()
        {
            // Arrange
            var school = new School { Id = 1, Name = "Test School" };
            _InMemoryDb.School.Add(school);
            _InMemoryDb.SaveChanges();

            // Act
            var result = service.SchoolNameExists("Test School");

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetStudentById_ReturnsCorrectStudent()
        {
            // Arrange
            var student = new Student {
                Id = 1,
                user = new ApplicationUser{ Salt = "testSalt" },
                FirstName = "Test", 
                LastName = "Student",
                Address = "171 Smart Lane"};
            _InMemoryDb.Student.Add(student);
            _InMemoryDb.SaveChanges();

            // Act
            var result = service.GetStudentById(1);

            // Assert
            Assert.That(result, Is.EqualTo(student));
        }
    }
}