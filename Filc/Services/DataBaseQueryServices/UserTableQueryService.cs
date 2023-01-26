using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Filc.Services.DataBaseQueryServices
{
    public class UserTableQueryService : IUserServiceFullAccess
    {
        private ESContext _db;
        public UserTableQueryService(ESContext esContext)
        {
            _db = esContext;
        }
        public List<ApplicationUser> GetAllUsers()
        {
            return _db.Users.ToList();
        }
        public ApplicationUser GetUserById(string id)
        {
            return _db.Users.FirstOrDefault(user => user.Id == id);
        }
        public ApplicationUser GetUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(user => user.Email == email);
        }
        public string GetSaltByEmail(string email)
        {
            var salt = _db.Users.FirstOrDefault(user => user.Email == email);
            if (salt != null)
            {
                return salt.Salt;
            }
            else
            {
                throw new KeyNotFoundException("Email not found.");
            }
        }
        
        public void AddUser(ApplicationUser user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        public void UpdateUser(ApplicationUser user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }
        public void DeleteUser(string id)
        {
            _db.Users.Remove(_db.Users.First(user => user.Id == id));
            _db.SaveChanges();
        }
    }
}
