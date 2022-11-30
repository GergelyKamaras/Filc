using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess
{
    public interface IUserServiceFullAccess
    {
        public List<ApplicationUser> GetAllUsers();
        public ApplicationUser GetUserById(string id);
        public ApplicationUser GetUserByEmail(string email);
        public string GetSaltByEmail(string email);
        
        public void UpdateUser(ApplicationUser user);
        public void DeleteUser(string id);
    }
}
