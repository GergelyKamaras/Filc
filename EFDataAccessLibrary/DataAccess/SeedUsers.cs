using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;

namespace EFDataAccessLibrary.DataAccess
{
    public class SeedUsers
    {
        public static async Task InitData(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            ApplicationUser govAdmin = new()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            ApplicationUser schoolAdmin = new()
            {
                UserName = "schooladmin@admin.com",
                Email = "schooladmin@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            ApplicationUser Teacher1 = new()
            {
                UserName = "teacher1@admin.com",
                Email = "teacher1@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };
            ApplicationUser Teacher2 = new()
            {
                UserName = "teacher2@admin.com",
                Email = "teacher2@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            ApplicationUser testStudent1 = new()
            {
                UserName = "teststudent1@gmail.com",
                Email = "teststudent1@gmail.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            ApplicationUser testStudent2 = new()
            {
                UserName = "teststudent2@gmail.com",
                Email = "teststudent2@gmail.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            ApplicationUser testStudent3 = new()
            {
                UserName = "teststudent3@gmail.com",
                Email = "teststudent3@gmail.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            ApplicationUser testStudent4 = new()
            {
                UserName = "teststudent4@gmail.com",
                Email = "teststudent4@gmail.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            ApplicationUser testStudent5 = new()
            {
                UserName = "teststudent5@gmail.com",
                Email = "teststudent5@gmail.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            await RegisterUser(govAdmin, "Government", roleManager, userManager);

            await RegisterUser(schoolAdmin, "SchoolAdmin", roleManager, userManager);

            await RegisterUser(Teacher1, "Teacher", roleManager, userManager);
            await RegisterUser(Teacher2, "Teacher", roleManager, userManager);

            await RegisterUser(testStudent1, "Student", roleManager, userManager);
            await RegisterUser(testStudent2, "Student", roleManager, userManager);
            await RegisterUser(testStudent3, "Student", roleManager, userManager);
            await RegisterUser(testStudent4, "Student", roleManager, userManager);
            await RegisterUser(testStudent5, "Student", roleManager, userManager);
        }

        private static async Task RegisterUser(ApplicationUser user, string role, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                await userManager.CreateAsync(user, user.PasswordHash);
                if (await roleManager.RoleExistsAsync(role))
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
