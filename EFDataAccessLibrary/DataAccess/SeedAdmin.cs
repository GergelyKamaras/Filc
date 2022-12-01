using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;

namespace EFDataAccessLibrary.DataAccess
{
    public class SeedAdmin
    {
        public static async Task InitAdminSeed(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            ApplicationUser seedUser = new()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };
            
            if (await userManager.FindByEmailAsync(seedUser.Email) == null)
            {
                await userManager.CreateAsync(seedUser, seedUser.PasswordHash);
                if (await roleManager.RoleExistsAsync("Government"))
                {
                    await userManager.AddToRoleAsync(seedUser, "Government");
                }
            }
        }
    }
}
