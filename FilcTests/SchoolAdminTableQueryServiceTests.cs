using Assert = NUnit.Framework.Assert;
using NSubstitute;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Microsoft.EntityFrameworkCore;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.Models.EntityViewModels.SchoolAdmin;

namespace FilcTests
{
    [TestFixture]
    public class SchoolAdminTableQueryServiceTests
    {
        public ESContext _InMemoryDb;
        public IUserServiceFullAccess userService;
        public SchoolAdminTableQueryService service;

        [SetUp]
        public void SetUp()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<ESContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;
            _InMemoryDb = new ESContext(options);

            userService = Substitute.For<IUserServiceFullAccess>();

            service = new SchoolAdminTableQueryService(_InMemoryDb, userService);
        }

        [Test]
        public void GetAllSchoolAdmins_HasAdmins_ReturnsAllSchoolAdmins()
        {
            // Arrange
            var school = new School { Id = 1 };

            var schoolAdmin1 = new SchoolAdmin 
            { 
                Id = 1, 
                user = new ApplicationUser 
                { 
                    Salt = "testSalt1"
                },
                FirstName = "Minta",
                LastName = "Adél",
                Address = "Minta utca 3.",
                School = school,
                BirthDate = DateTime.Now
            };
            var schoolAdmin2 = new SchoolAdmin 
            { 
                Id = 2, 
                user = new ApplicationUser 
                { 
                    Salt = "testSalt2" 
                },
                FirstName = "Minta",
                LastName = "Lajos",
                Address = "Minta utca 3.",
                School = school,
                BirthDate = DateTime.Now
            };

            _InMemoryDb.SchoolAdmin.Add(schoolAdmin1);
            _InMemoryDb.SchoolAdmin.Add(schoolAdmin2);
            _InMemoryDb.SaveChanges();

            //Act
            List<SchoolAdminDTO> result = service.GetAllSchoolAdmins();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result[0], Is.InstanceOf<SchoolAdminDTO>());

        }

        [Test]
        public void GetAllSchoolAdmins_EmptyDb_ReturnsNull()
        {
            //Act
            List<SchoolAdminDTO> result = service.GetAllSchoolAdmins();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(0));
        }

        [Test]
        public void GetSchoolAdminById_ExistingId_ReturnsSchoolAdminDTO()
        {
            // Arrange
            var school = new School { Id = 1 };

            var schoolAdmin1 = new SchoolAdmin
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Salt = "testSalt1"
                },
                FirstName = "Minta",
                LastName = "Adél",
                Address = "Minta utca 3.",
                School = school,
                BirthDate = DateTime.Now
            };

            _InMemoryDb.SchoolAdmin.Add(schoolAdmin1);
            _InMemoryDb.SaveChanges();

            //Act
            var result = service.GetSchoolAdminById(1);

            //Assert 
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<SchoolAdminDTO>());
            Assert.That(result.FirstName, Is.EqualTo("Minta"));
        }

        [Test]
        public void GetSchoolAdminById_NonExistentId_ReturnsNull()
        {
            //Act //Assert
            var exception = Assert.Catch<InvalidOperationException>(() => service.GetSchoolAdminById(1));
        }

        [Test]
        public void AddSchoolAdmin_NewAdmin_AddsSchoolAdmin()
        {
            // Arrange
            var school = new School { Id = 1 };

            var schoolAdmin1 = new SchoolAdmin
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testSalt1",
                    UserName = "Sarah@Admin.com",
                    Email = "Sarah@Admin.com"
                },
                FirstName = "Sarah",
                LastName = "Example",
                Address = "3 Example Street",
                School = school,
                BirthDate = DateTime.Now
            };

            userService.GetUserByEmail(schoolAdmin1.user.Email).Returns(schoolAdmin1.user);

            //Act
            //var result = service.AddSchoolAdmin(schoolAdmin1);

            //Assert
            //Assert.That(result.Status, Is.EqualTo("Success"));
        }

        [Test]
        public void AddSchoolAdmin_ExistingAdmin_ThrowsError()
        {
            // Arrange
            var school = new School { Id = 1 };

            var schoolAdmin1 = new SchoolAdmin
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testSalt1",
                    UserName = "Sarah@Admin.com",
                    Email = "Sarah@Admin.com"
                },
                FirstName = "Sarah",
                LastName = "Example",
                Address = "3 Example Street",
                School = school,
                BirthDate = DateTime.Now
            };
            _InMemoryDb.SchoolAdmin.Add(schoolAdmin1);
            _InMemoryDb.SaveChanges();

            userService.GetUserByEmail(schoolAdmin1.user.Email).Returns(schoolAdmin1.user);

            //Act, Assert
            Assert.Catch<ArgumentException>(()=> service.AddSchoolAdmin(schoolAdmin1));
        }

        [Test]
        public void UpdateSchoolAdmin_ExistingAdmin_UpdatesAdmin()
        {

        }

        [Test]
        public void UpdateSchoolAdmin_NonExistentAdmin_ThrowsError()
        {

        }

        [Test]
        public void DeleteSchoolAdmin_ExistingAdmin_DeletesSchoolAdmin()
        {

        }

        [Test]
        public void DeleteSchoolAdmin_NonExistentAdmin_ThrowsError()
        {

        }
    }
}
