using Microsoft.AspNetCore.Identity;
using SeeSharpersCinema.Data.Models.User;
using System;
using System.Security.Claims;

namespace SeeSharpersCinema.Models.Database
{
    public static class UserAndRoleDataInitializer
    {

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {

            foreach (string roleName in Enum.GetNames(typeof(RoleType)))
            {
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = roleName;
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }
            }
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@ssc.nl").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin";
                user.Email = "admin@ssc.nl";

                IdentityResult result = userManager.CreateAsync(user, "Admin1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Desk").Wait();
                }
            }

            if (userManager.FindByEmailAsync("Noel").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Noel";
                user.Email = "noel@ssc.nl";

                IdentityResult result = userManager.CreateAsync(user, "Noel1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }

            if (userManager.FindByEmailAsync("Loes").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Loes";
                user.Email = "loes@ssc.nl";

                IdentityResult result = userManager.CreateAsync(user, "Loes1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Desk").Wait();
                }
            }

            if (userManager.FindByEmailAsync("Piet").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Ilona";
                user.Email = "ilona@ssc.nl";

                IdentityResult result = userManager.CreateAsync(user, "Ilona1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
        }


    }
}
