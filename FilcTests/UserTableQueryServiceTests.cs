using EFDataAccessLibrary.DataAccess;
using Filc.Services.DataBaseQueryServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Org.BouncyCastle.Crypto.Parameters;

namespace FilcTests
{
    internal class UserTableQueryServiceTests
    {
        public ESContext _InMemoryDb;
        public UserTableQueryService service;
        [SetUp]
        public void Setup()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<ESContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;
            _InMemoryDb = new ESContext(options);

            service = new UserTableQueryService(_InMemoryDb);
        }

        [Test]
        public void AddUser_UserAdded_IsInDb()
        {
            // Arrange
            ApplicationUser user1 = new ApplicationUser() { Salt = "saltymalty", Email = "test1@test.com", PasswordHash = "Jolanka" };

            // Act
            service.AddUser(user1);

            // Assert
            Assert.That(_InMemoryDb.Users.FirstOrDefault(user => user.Email == user1.Email).Email == user1.Email);
        }

        [Test]
        public void AdddUser_UserAddedTwice_ThrowsError()
        {
            // Arrange
            ApplicationUser user1 = new ApplicationUser() { Salt = "saltymalty", Email = "test1@test.com", PasswordHash = "Jolanka" };

            // Act
            service.AddUser(user1);
            Assert.Catch<ArgumentException>(() => service.AddUser(user1));
        }
        
        [Test]
        public void GetAllUsers_HasUsers_ReturnsAddedUsers()
        {
            string testSalt = "SaltyMalty";
            // Arrange
            ApplicationUser user1 = new ApplicationUser() { Salt = testSalt, Email = "test1@test.com", PasswordHash = "Jolanka"};
            ApplicationUser user2 = new ApplicationUser() { Salt = testSalt, Email = "test2@test.com", PasswordHash = "Jolanka" };

            // Act
            _InMemoryDb.Users.Add(user1);
            _InMemoryDb.Users.Add(user2);

            _InMemoryDb.SaveChanges();

            // Assert
            List<ApplicationUser> users = service.GetAllUsers();
            Assert.That(users.Count == 2 && 
                        users.Any(user => user.Email == user1.Email) && 
                        users.Any(user => user.Email == user2.Email));
        }

        [Test]
        public void GetUserById_UserAdded_ReturnsUser()
        {
            // Arrange
            ApplicationUser user1 = new ApplicationUser() { Id = $"{new Guid()}", Salt = "SaltyMalty", Email = "test1@test.com", PasswordHash = "Jolanka" };

            // Act
            _InMemoryDb.Users.Add(user1);

            _InMemoryDb.SaveChanges();

            ApplicationUser resultUser = service.GetUserById(user1.Id);
            
            //Assert
            Assert.That(resultUser.Id == user1.Id);
        }

        [Test]
        public void GetUserById_NoSuchUser_ReturnsNull()
        {
            // Assert
            Assert.That(service.GetUserById($"{new Guid()}") == null);
        }

        [Test]
        public void GetUserByEmail_UserAdded_ReturnsUser()
        {
            // Arrange
            ApplicationUser user1 = new ApplicationUser() { Id = $"{new Guid()}", Salt = "SaltyMalty", Email = "test1@test.com", PasswordHash = "Jolanka" };

            // Act
            _InMemoryDb.Users.Add(user1);

            _InMemoryDb.SaveChanges();

            ApplicationUser resultUser = service.GetUserByEmail(user1.Email);

            //Assert
            Assert.That(resultUser.Id == user1.Id);
        }

        [Test]
        public void GetUserByEmail_NoSuchUser_ReturnsNull()
        {
            // Assert
            Assert.That(service.GetUserByEmail("NoSuchEmail@InTheWorld.XX") == null);
        }

        [Test]
        public void GetSaltByEmail_UserAdded_ReturnSalt()
        {
            // Arrange
            ApplicationUser user1 = new ApplicationUser() { Id = $"{new Guid()}", Salt = "SaltyMalty", Email = "test1@test.com", PasswordHash = "Jolanka" };

            // Act
            _InMemoryDb.Users.Add(user1);

            _InMemoryDb.SaveChanges();

            string resultSalt = service.GetSaltByEmail(user1.Email);

            //Assert
            Assert.That(resultSalt == user1.Salt);
        }

        [Test]
        public void GetSaltByEmail_NoSuchUser_ReturnsNull()
        {
            // Assert
            Assert.That(service.GetSaltByEmail("NoSuchEmail@InTheWorld.XX") == null);
        }

        [Test]
        public void UpdateUser_UserExists_UserIsUpdated()
        {
            // Arrange
            ApplicationUser user1 = new ApplicationUser() { Id = $"{new Guid()}", Salt = "SaltyMalty", Email = "test1@test.com", PasswordHash = "Jolanka" };

            // Act
            _InMemoryDb.Users.Add(user1);
            _InMemoryDb.SaveChanges();

            string newEmail = "newtestemail@test.com";
            string newPasswordHash = "newPasswordHash";
            string newSalt = "SaltyMcSaltersson";

            user1.Email = newEmail;
            user1.PasswordHash = newPasswordHash;
            user1.Salt = newSalt;

            service.UpdateUser(user1);

            ApplicationUser resultUser = _InMemoryDb.Users.FirstOrDefault(user => user.Id == user1.Id);
            
            // Assert
            Assert.That(resultUser.Salt == newSalt &&
                        resultUser.Email == newEmail &&
                        resultUser.PasswordHash == newPasswordHash);
        }

        [Test]
        public void UpdateUser_UserDoesntExist_ThrowsError()
        {
            // Arrange
            ApplicationUser user1 = new ApplicationUser() { Id = $"{new Guid()}", Salt = "SaltyMalty", Email = "test1@test.com", PasswordHash = "Jolanka" };

            // Assert
            Assert.Catch<DbUpdateConcurrencyException>(() => service.UpdateUser(user1));
        }

        [Test]
        public void DeleteUser_UserExists_IsDeleted()
        {
            // Arrange
            ApplicationUser user1 = new ApplicationUser() { Id = $"{new Guid()}", Salt = "SaltyMalty", Email = "test1@test.com", PasswordHash = "Jolanka" };

            // Act
            _InMemoryDb.Users.Add(user1);
            _InMemoryDb.SaveChanges();

            service.DeleteUser(user1.Id);

            // Assert
            Assert.That(_InMemoryDb.Users.FirstOrDefault(user => user.Id == user1.Id) == null);
        }

        [Test]
        public void DeleteUser_UserDoesntExist_ThrowsError()
        {
            Assert.Throws<InvalidOperationException>(() => service.DeleteUser("NoSuchIdInTheWorld"));
        }
    }
}
