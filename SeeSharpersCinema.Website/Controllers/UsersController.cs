using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Data.Models.User;
using SeeSharpersCinema.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Website.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        /// <summary>
        /// Constructor UsersController
        /// </summary>
        /// <param name="userManager">Constructor needs UserManager of IdentityUser object</param>
        /// <param name="signInManager">Constructorneeds SignInManager of IdentityUser object</param>
        /// <param name="roleManager">Constructor needs RoleManager of IdentityUser object</param>
        public UsersController(UserManager<IdentityUser> userManager,
                               SignInManager<IdentityUser> signInManager,
                               RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        /// <summary>
        /// Gets a list of all the users and their role(s)
        /// </summary>
        
        public async Task<IActionResult> Manage()
        {
            var users = userManager.Users.ToList();
            UserViewModel model = new UserViewModel();            

            foreach (var user in users)
            {
                UserRole userRole = new UserRole();
                userRole.User = user;
                userRole.Roles = (List<string>)await userManager.GetRolesAsync(user);
                
                model.Users.Add(userRole);
            }

            return View(model);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="userId">the UserID to be deleted</param>
        
        [Route("Users/DeleteUser/{UserId}")]
        public async Task<IActionResult> DeleteUser(string UserId)
        {
            IdentityUser user = await userManager.FindByIdAsync(UserId);

            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded) 
                { 
                    return RedirectToAction("Manage", "Users");
                }
            }
            else 
            { 
                ModelState.AddModelError("", "User Not Found");
            }

            return RedirectToAction("Manage","Users");
        }

        /// <summary>
        /// Gets the user information
        /// </summary>
        /// <param name="userId">the UserID of which the info for</param>
        
        [HttpGet]
        [Route("Users/Edit/{UserId}")]
        public async Task<IActionResult> Edit(string UserId)
        {
            IdentityUser user = await userManager.FindByIdAsync(UserId);

            UserRole userRole = new UserRole();
            userRole.User = user;
            userRole.Roles = (List<string>)await userManager.GetRolesAsync(user);

            EditUserViewModel model = new EditUserViewModel();
            model.UserRole = userRole;
            model.RoleTypes = Enum.GetValues(typeof(RoleType))
                .Cast<RoleType>()
                .Select(r => r.ToString())
                .ToList();

            return View(model);
        }

        /// <summary>
        /// Edit user information
        /// </summary>
        /// <param name="userId">the UserID of which the infor to be modified</param>
        /// <param name="UserName">the (new) UserName</param>
        /// <param name="Email">the (new) Email adress</param>
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("UserId,UserName,Email")] EditUserViewModel model)
        {

            IdentityUser user = await userManager.FindByIdAsync(model.UserId);
            user.Email = model.Email;
            user.UserName = model.UserName;

            await userManager.UpdateAsync(user);
            return RedirectToAction("Manage", "Users", new { id = model.UserId });
        }

        /// <summary>
        /// Add a role to existing user
        /// </summary>
        /// <param name="userId">the UserID to which to add the role</param>
        /// <param name="role">role to be added</param>
        
        public async Task<IActionResult> AddRole(string userId, string role)
        {
            IdentityUser user = await userManager.FindByIdAsync(userId);

            await userManager.AddToRoleAsync(user, role);
            return RedirectToAction("Edit", "Users", new { id = userId });
        }

        /// <summary>
        /// Remove a role from existing user
        /// </summary>
        /// <param name="userId">the UserID to which to remove the role</param>
        /// <param name="role">role to be removed</param>
        
        public async Task<IActionResult> RemoveRole(string userId, string role)
        {
            IdentityUser user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user, role);
            return RedirectToAction("Edit", "Users", new { id = userId });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/Account/AccessDenied")]
        public ActionResult AccessDenied()
        {
            return LocalRedirect("/Account/AccessDenied");
        }

    }
}
