using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    /// <summary>
    /// UserViewModel used by the Manage View.
    /// </summary>
    public class UserViewModel
    {
        public List<UserRole> Users { get; set; }

        public UserViewModel()
        {
            this.Users = new List<UserRole>();
        }
    }

    /// <summary>
    /// UserRole used by the UserViewModel. Combines user and their roles
    /// </summary>
    public class UserRole
    {
        public List<string> Roles { get; set; }
        public IdentityUser User { get; set; }
    }
}
