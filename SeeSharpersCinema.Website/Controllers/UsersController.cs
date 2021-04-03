﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Website.Controllers
{
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
        /// Signout user and return home
        /// </summary>
        /// <returns>Redirects to home</returns>
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }


        /// <summary>
        /// Register Action
        /// </summary>
        /// <returns>Register View</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="model">RegisterUserViewModel used to register new user</param>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        /// <summary>
        /// Login Action
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// On succeed login user and redirect to home. Else show Error.
        /// </summary>
        /// <param name="model">LoginViewModel used to verify and login the user</param>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result
                    = await signInManager.PasswordSignInAsync(
                            model.Name,
                            model.Password,
                            isPersistent: false,
                            lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                    //todo change to previous page
                }
                ModelState.AddModelError("", "Login failed.");
            }

            return View(model);
        }

        //[Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> Manage()
        {
            //var users = userManager.Users.ToList();
            //var roles = await userManager.GetRolesAsync(users[1]);

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
        //[Authorize(Roles = "Admin, Manager")]
        //[ValidateAntiForgeryToken]
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

    }
}
