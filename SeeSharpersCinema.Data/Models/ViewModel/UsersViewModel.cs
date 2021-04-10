using Microsoft.AspNetCore.Identity;
using SeeSharpersCinema.Data.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
