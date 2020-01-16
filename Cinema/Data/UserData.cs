using Cinema.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data
{
    public class UserData
    {
        public static async Task Initialize(ApplicationDbContext context,
                                                  UserManager<ApplicationUser> userManager,
                                                  RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            string adminId1 = "";

            string role1 = "Admin";
            string desc1 = "This is the administrator role";

            string role2 = "Member";
            string desc2 = "This is the member role";

            string passwordAdmin = "Admin.123";
            string passwordUser = "User.123";


            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByEmailAsync("admin@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FirstName = "Voislav",
                    LastName = "Gruevski",
                    City = "Skopje",
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, passwordAdmin);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;

            }
            if (await userManager.FindByEmailAsync("user@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com",
                    FirstName = "Johny",
                    LastName = "Bravo",
                    City = "Kicevo",
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, passwordUser);
                    await userManager.AddToRoleAsync(user, role2);
                }

            }

        }
    }
}
