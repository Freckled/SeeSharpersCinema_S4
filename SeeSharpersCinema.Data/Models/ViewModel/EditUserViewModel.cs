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
    /// EditUserViewModel used by the EditUser view (index)
    /// this combines the UserRole and Roletypes and specific user information
    /// </summary>
    public class EditUserViewModel
    {
        public UserRole UserRole { get; set; }
        public List<string> RoleTypes { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
