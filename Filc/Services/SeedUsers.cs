using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.ViewModel;

namespace EFDataAccessLibrary.DataAccess
{
    public class SeedUsers
    {
        public static async Task InitData(IGovernmentAdminServiceFullAccess govService, IRegistration registration)
        {
            ApplicationUser govAdminUser = new()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            GovernmentAdmin admin = new GovernmentAdmin();
            admin.user = govAdminUser;

            if (await registration.Register(new RegistrationModel(govAdminUser, "Government")) == true)
            {
                govService.AddGovernmentAdmin(admin);
            };
        }
    }
}
