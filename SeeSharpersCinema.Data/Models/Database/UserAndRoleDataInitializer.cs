using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SeeSharpersCinema.Models.Database
{
    public static class UserAndRoleDataInitializer
    {

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Desk").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Desk";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
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

                IdentityResult result = userManager.CreateAsync(user, "noel1234").Result;

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

                IdentityResult result = userManager.CreateAsync(user, "loes1234").Result;

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

                IdentityResult result = userManager.CreateAsync(user, "ilona1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
        }


    }
}
