using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class GovernmentAdminTableQueryService : IGovernmentAdminServiceFullAccess
    {
        private ESContext _db;
        private IUserServiceFullAccess _userService;
        private IRegistration _registration;
        public GovernmentAdminTableQueryService(ESContext esContext, IUserServiceFullAccess usrService, IRegistration registrationService)
        {
            _registration = registrationService;
            _db = esContext;
            _userService = usrService;
        }

        public List<GovernmentAdmin> GetAllGovernmentAdmins()
        {
            return _db.GovernmentAdmin.Include(admin => admin.user)
                .ToList();
        }
        public GovernmentAdmin GetGovernmentAdmin(int id)
        {
            return _db.GovernmentAdmin.Include(admin => admin.user)
                .First(x => x.Id == id);
        }
        public async Task<JWTAuthenticationResponse> AddGovernmentAdmin(GovernmentAdmin governmentAdmin)
        {
            try
            {
                if (await _registration.Register(new RegistrationModel(governmentAdmin.user, "Government")) != true)
                {
                    throw new Exception("Error registering user!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during user registration!" + e);
            }
            ApplicationUser user = _userService.GetUserByEmail(governmentAdmin.user.Email);
            governmentAdmin.user = user;
            _db.GovernmentAdmin.Add(governmentAdmin);
            _db.SaveChanges();

            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration successful!"
            };
        }
        public void RemoveGovernmentAdmin(int id)
        {
            _db.GovernmentAdmin.Remove(_db.GovernmentAdmin.First(x => x.Id == id));
            _db.SaveChanges();
        }
        public void UpdateGovernmentAdmin(GovernmentAdmin governmentAdmin)
        {
            governmentAdmin.user = _db.GovernmentAdmin.First(admin => admin.Id == governmentAdmin.Id).user;
            _db.GovernmentAdmin.Update(governmentAdmin);
            _db.SaveChanges();
        }
    }
}
