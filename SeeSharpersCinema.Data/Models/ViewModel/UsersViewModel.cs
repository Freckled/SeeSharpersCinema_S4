using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    public class UserViewModel
    {
        public List<UserRole> Users { get; set; }

        public UserViewModel()
        {
            this.Users = new List<UserRole>();
        }
    }

    public class UserRole
    {
        public List<string> Roles { get; set; }
        public IdentityUser User { get; set; }
    }
}
