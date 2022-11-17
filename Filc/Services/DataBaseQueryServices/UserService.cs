using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Filc.Services.DataBaseQueryServices
{
    public class UserService
    {
        private ESContext _db;
        public UserService(ESContext esContext)
        {
            _db = esContext;
        }

        public List<IdentityUser> GetAllUsers()
        {
            return _db.Users.ToList();
        }
        public IdentityUser GetUserById(string id)
        {
            return _db.Users.First(user => user.Id == id);
        }

        public IdentityUser GetUserByEmail(string email)
        {
            return _db.Users.First(user => user.Email == email);
        }

        public void UpdateUser(IdentityUser user)
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
