﻿using Microsoft.AspNetCore.Identity;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface IUserServiceFullAccess
    {
        public List<IdentityUser> GetAllUsers();
        public IdentityUser GetUserById(string id);
        public IdentityUser GetUserByEmail(string email);
        public void AddUser(IdentityUser user);
        public void UpdateUser(IdentityUser user);
        public void DeleteUser(string id);
    }
}
