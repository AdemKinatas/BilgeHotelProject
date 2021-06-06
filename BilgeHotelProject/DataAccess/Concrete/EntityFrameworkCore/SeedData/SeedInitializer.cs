using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore.SeedData
{
    public static class SeedInitializer
    {
        public static async Task Seed(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var receptionRole = await roleManager.FindByNameAsync("Reception");
            if (receptionRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Reception" });
            }

            var hrRole = await roleManager.FindByNameAsync("HumanResources");
            if (hrRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "HumanResources" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "admin",
                    FirstName = "Bilge",
                    LastName = "Hotel",
                    Email = "bilge@hotel.com"
                };

                await userManager.CreateAsync(user, "Test123+");
                await userManager.AddToRoleAsync(user, "Admin");
            }

            var receptionUser = await userManager.FindByNameAsync("reception");
            if (receptionUser == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "reception",
                    FirstName = "Bilge",
                    LastName = "Hotel",
                    Email = "bilge@hotel.com"
                };

                await userManager.CreateAsync(user, "Test123+");
                await userManager.AddToRoleAsync(user, "Reception");
            }

            var hrUser = await userManager.FindByNameAsync("human resources");
            if (hrUser == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "humanresources",
                    FirstName = "Bilge",
                    LastName = "Hotel",
                    Email = "bilge@hotel.com"
                };

                await userManager.CreateAsync(user, "Test123+");
                await userManager.AddToRoleAsync(user, "HumanResources");
            }

            var memberUser = await userManager.FindByNameAsync("member");
            if (memberUser == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "member",
                    FirstName = "Ali",
                    LastName = "Veli",
                    Email = "ali@veli.com"
                };

                await userManager.CreateAsync(user, "Test123+");
                await userManager.AddToRoleAsync(user, "Member");
            }
        }
    }
}
