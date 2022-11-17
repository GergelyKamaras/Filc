﻿using EFDataAccessLibrary.DataAccess;
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
        public IdentityUser GetUserById(string id)
        {
            return _db.Users.First(user => user.Id == id);
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