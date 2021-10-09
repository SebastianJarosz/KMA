using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMA.Models;

namespace KMA.Database
{
    public class IdentityDataInitializer
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, roleManager);
        }

        public static void SeedUsers (UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                User user = new User()
                {
                    UserName = "Admin",
                    Email = "admin@localhost",
                    Name = "Admin",
                    Surname = "Admin",
                    Role = roleManager.Roles.FirstOrDefault(r => r.Name=="Admin")
                    
            };
                IdentityResult result = userManager.CreateAsync
                (user, "Nixdorf1@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, user.RoleName).Wait();
                }
            }
        }

        public static void SeedRoles
    (RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                Role role = new Role();
                role.Name = "NormalUser";
                role.Description = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                Role role = new Role();
                role.Name = "Admin";
                role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
