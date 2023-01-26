using Assert = NUnit.Framework.Assert;
using NSubstitute;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Microsoft.EntityFrameworkCore;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;

namespace FilcTests
{
    [TestFixture]
    public class GovernmentAdminTableQueryServiceTests
    {
        public ESContext _InMemoryDb;
        public IUserServiceFullAccess userService;
        public GovernmentAdminTableQueryService service;


        [SetUp]
        public void Setup()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<ESContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;
            _InMemoryDb = new ESContext(options);

            userService = Substitute.For<IUserServiceFullAccess>();
            
            service = new GovernmentAdminTableQueryService(_InMemoryDb, userService);
        }

        [Test]
        public void GetAllGovernmentAdmins_HasAdmins_ReturnsAllGovAdmins()
        {
            // Arrange
            var govAdmin1 = new GovernmentAdmin { Id = 1, user = new ApplicationUser { Salt = "testSalt1"} };
            var govAdmin2 = new GovernmentAdmin { Id = 2, user = new ApplicationUser { Salt = "testSalt2"} };

            _InMemoryDb.GovernmentAdmin.Add(govAdmin1);
            _InMemoryDb.GovernmentAdmin.Add(govAdmin2);
            _InMemoryDb.SaveChanges();

            var listOfAdmins = new List<GovernmentAdmin>
            {
                govAdmin1,
                govAdmin2
            };

            //Act
            var result = service.GetAllGovernmentAdmins();

            //Assert
            Assert.That(result, Is.EquivalentTo(listOfAdmins));
        }

        [Test]
        public void GetAllGovernmentAdmins_EmptyDB_ReturnsNull()
        {
            //Arrange

            //Act
            var result = service.GetAllGovernmentAdmins();

            Assert.IsEmpty(result);
        }

        [Test]
        public void GetGovernmentAdmin_Found_ReturnsGovernmentAdmin()
        {
            //Arrange
            var govAdmin1 = new GovernmentAdmin { Id = 1, user = new ApplicationUser { Salt = "testSalt1" } };
            _InMemoryDb.GovernmentAdmin.Add(govAdmin1);
            _InMemoryDb.SaveChanges();

            //Act
            var result = service.GetGovernmentAdmin(govAdmin1.Id);

            //Assert
            Assert.That(result, Is.EqualTo(govAdmin1));
        }

        [Test]
        public void GetGovernmentAdmin_NotFound_ReturnsNull()
        {
            //Arrange
            var govAdmin1 = new GovernmentAdmin { Id = 1, user = new ApplicationUser { Salt = "testSalt1" } };

            //Act
            var result = service.GetGovernmentAdmin(govAdmin1.Id);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void AddGovernmentAdmin_NotExisting_AddsGovernmentAdmin()
        {
            //Arrange
            var govAdmin1 = new GovernmentAdmin
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Salt = "testSalt1",
                    Email = "testemail1@test.com"
                }
            };
            userService.GetUserByEmail(govAdmin1.user.Email).Returns(govAdmin1.user);

            //Act
            var response = service.AddGovernmentAdmin(govAdmin1);

            //Assert
            var data = _InMemoryDb.GovernmentAdmin.FirstOrDefault(x => x.Id == govAdmin1.Id);
            Assert.IsNotNull(data);
            Assert.That(data, Is.EqualTo(govAdmin1));
            Assert.That(response.Status, Is.EqualTo("Success"));
        }

        [Test]
        public void AddGovernmentAdmin_Existing_DoesntAddAnotherGovernmentAdmin()
        {
            //Arrange
            var govAdmin1 = new GovernmentAdmin { Id = 1, user = new ApplicationUser { Salt = "testSalt1" } };
            _InMemoryDb.GovernmentAdmin.Add(govAdmin1);
            _InMemoryDb.SaveChanges();

            //Act
            service.AddGovernmentAdmin(govAdmin1);

            //Assert
            var count = _InMemoryDb.GovernmentAdmin.Count();
            Assert.That(count, Is.EqualTo(1));

        }

        [Test]
        public void RemoveGovernmentAdmin_Existing_RemovesGovAdmin()
        {
            //Arrange
            var govAdmin1 = new GovernmentAdmin { Id = 1, user = new ApplicationUser { Salt = "testSalt1" } };
            _InMemoryDb.GovernmentAdmin.Add(govAdmin1);
            _InMemoryDb.SaveChanges();

            //Act
            service.RemoveGovernmentAdmin(govAdmin1.Id);

            //Assert
            var data = _InMemoryDb.GovernmentAdmin.FirstOrDefault(x => x.Id == govAdmin1.Id);
            Assert.That(data, Is.EqualTo(null));
        }

        [Test]
        public void RemoveGovernmentAdmin_NonExistent_DoesntRemoveAnything()
        {
            // Arrange
            var govAdmin1 = new GovernmentAdmin { Id = 1, user = new ApplicationUser { Salt = "testSalt1" } };
            var govAdmin2 = new GovernmentAdmin { Id = 2, user = new ApplicationUser { Salt = "testSalt2" } };

            _InMemoryDb.GovernmentAdmin.Add(govAdmin1);
            _InMemoryDb.GovernmentAdmin.Add(govAdmin2);
            _InMemoryDb.SaveChanges();

            //Act
            service.RemoveGovernmentAdmin(3);

            //Assert
            var count = _InMemoryDb.GovernmentAdmin.Count();
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void UpdateGovernmentAdmin_Existing_UpdatesAdmin()
        {
            //Arrange
            var govAdmin1 = new GovernmentAdmin
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Salt = "testSalt1",
                    Email = "testemail1@test.com"
                }
            };
            _InMemoryDb.GovernmentAdmin.Add(govAdmin1);
            _InMemoryDb.SaveChanges();

            var govAdmin2 = govAdmin1;
            govAdmin2.user.Email = "updatedemail@test.com";

            //Act
            service.UpdateGovernmentAdmin(govAdmin2);

            //Assert
            var data = _InMemoryDb.GovernmentAdmin.FirstOrDefault(x => x.Id == govAdmin1.Id);
            Assert.That(data.user.Email, Is.EqualTo("updatedemail@test.com"));
        }

        [Test]
        public void UpdateGovernmentAdmin_NonExistent_DoesntUpdateAdmin()
        {
            //Arrange
            var govAdmin1 = new GovernmentAdmin
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Salt = "testSalt1",
                    Email = "testemail1@test.com"
                }
            };
            _InMemoryDb.GovernmentAdmin.Add(govAdmin1);
            _InMemoryDb.SaveChanges();

            var govAdmin2 = new GovernmentAdmin
            {
                Id = 2,
                user = new ApplicationUser
                {
                    Salt = "testSalt2",
                    Email = "testemail2@test.com"
                }
            };

            //Act
            service.UpdateGovernmentAdmin(govAdmin2);

            //Assert
            var data = _InMemoryDb.GovernmentAdmin.FirstOrDefault(x => x.Id == govAdmin1.Id);
            Assert.That(data.user.Email, Is.EqualTo("testemail1@test.com"));
        }
    }
}
