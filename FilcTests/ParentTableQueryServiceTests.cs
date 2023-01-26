using Assert = NUnit.Framework.Assert;
using NSubstitute;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Microsoft.EntityFrameworkCore;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.Models.ViewModels.Parent;

namespace FilcTests
{
    [TestFixture]
    public class ParentTableQueryServiceTests
    {
        public ESContext _InMemoryDb;
        public IUserServiceFullAccess userService;
        public ParentTableQueryService service;

        [SetUp]
        public void SetUp()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<ESContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;
            _InMemoryDb = new ESContext(options);

            userService = Substitute.For<IUserServiceFullAccess>();

            service = new ParentTableQueryService(_InMemoryDb, userService);
        }

        [Test]
        public void GetParent_ExistingId_ReturnsParent()
        {
            //Arrange
            var parent1 = new Parent
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testSalt1",
                    UserName = "parent@parent.com"
                }
            };
            _InMemoryDb.Parent.Add(parent1);
            _InMemoryDb.SaveChanges();

            //Act
            var result = service.GetParent(parent1.Id);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ParentDTO>());
        }

        [Test]
        public void GetParent_NonExistentId_ThrowsError()
        {
            //Arrange
            var parent1 = new Parent
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testSalt1",
                    UserName = "parent@parent.com"
                }
            };
            _InMemoryDb.Parent.Add(parent1);
            _InMemoryDb.SaveChanges();

            //Act
            var exception = Assert.Catch<InvalidOperationException>(() => service.GetParent(2));

            //Assert
            Assert.That(exception.Message, Is.EqualTo("Sequence contains no elements"));
        }

        [Test]
        public void AddParent_NewParent_AddsParentReturnsSuccess()
        {
            //Arrange
            var parent1 = new Parent
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testSalt1",
                    UserName = "parent@parent.com"
                }
            };
            _InMemoryDb.Parent.Add(parent1);
            _InMemoryDb.SaveChanges();

            //Act
            var response = service.AddParent(parent1);

            //Assert
            var data = _InMemoryDb.Parent.FirstOrDefault(p => p.Id == parent1.Id);
            Assert.IsNotNull(data);
            Assert.That(data.Id, Is.EqualTo(parent1.Id));
            Assert.That(response.Status, Is.EqualTo("Success"));

        }

        [Test]
        public void AddParent_ExistingParent_ThrowsError()
        {
            //Arrange
            var parent1 = new Parent
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testSalt1",
                    UserName = "parent@parent.com"
                }
            };
            _InMemoryDb.Parent.Add(parent1);
            _InMemoryDb.SaveChanges();

            userService.GetUserByEmail(parent1.user.Email).Returns(parent1.user);

            //Act //Assert
            var exception = Assert.Catch<ArgumentException>(() => service.AddParent(parent1));
        }

        [Test]
        public void UpdateParent_ExistingParent_UpdatesParent()
        {
            //Arrange
            var parent1 = new Parent
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testSalt1",
                    UserName = "parent@parent.com",
                    Email = "parent@parent.com"
                },
                Children = new List<Student>()
            };
            _InMemoryDb.Parent.Add(parent1);
            _InMemoryDb.SaveChanges();

            parent1.user.Salt = "testSalt2";

            //Act
            service.UpdateParent(parent1);

            //Assert
            Parent data = _InMemoryDb.Parent.FirstOrDefault(p => p.Id == 1);
            Assert.That(data, Is.Not.Null);
            Assert.That(data.user.Salt, Is.EqualTo("testSalt2"));
        }

        [Test]
        public void UpdateParent_NonExistentParent_ThrowsError()
        {
            //Arrange
            var parent1 = new Parent
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testSalt1",
                    UserName = "parent@parent.com",
                    Email = "parent@parent.com"
                },
                Children = new List<Student>()
            };


            //Act //Assert
            var exception = Assert.Catch<DbUpdateConcurrencyException>(() => service.UpdateParent(parent1));
        }

        [Test]
        public void DeleteParent_ExistingParent_DeletesParent()
        {
            //Arrange
            var parent1 = new Parent
            {
                Id = 1,
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Salt = "testSalt1",
                    UserName = "parent@parent.com"
                }
            };

            userService.GetUserByEmail(parent1.user.Email).Returns(parent1.user);

            _InMemoryDb.Parent.Add(parent1);
            _InMemoryDb.SaveChanges();

            //Act
            service.DeleteParent(parent1.Id);

            //Assert
            var data = _InMemoryDb.Parent.FirstOrDefault(x => x.Id == parent1.Id);
            Assert.That(data, Is.EqualTo(null));
        }

        [Test]
        public void DeleteParent_NonExistentParent_ThrowsError()
        {
            //Act //Assert
            var exception = Assert.Catch<InvalidOperationException>(() => service.DeleteParent(1));
        }
    }
}
