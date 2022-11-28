using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public static class SeedRoles
    {
        
        public static async Task InitRoleSeeds(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.Goverment.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Goverment.ToString())).ConfigureAwait(true);
            }
            if (!await roleManager.RoleExistsAsync(Roles.SchoolAdmin.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.SchoolAdmin.ToString())).ConfigureAwait(true);
            }
            if (!await roleManager.RoleExistsAsync(Roles.Teacher.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Teacher.ToString())).ConfigureAwait(true);
            }
            if (!await roleManager.RoleExistsAsync(Roles.Student.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Student.ToString())).ConfigureAwait(true);
            }
            if (!await roleManager.RoleExistsAsync(Roles.Parent.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Parent.ToString())).ConfigureAwait(true); ;
            }
            
        }
    }
}
