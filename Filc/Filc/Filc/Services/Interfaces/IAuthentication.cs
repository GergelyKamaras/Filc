﻿namespace Filc.Filc.Filc.Services.Interfaces
{
    public interface IAuthentication
    {
        // Looks up all user tables and returns true if the given email is registered already
        public bool IsEmailTaken(string email);
        // Looks up all user tables and returns a matching user if one exists
        public IUser GetUser(string email);
    }
}
