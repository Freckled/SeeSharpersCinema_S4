using Microsoft.AspNetCore.Identity;
using SeeSharpersCinema.Data.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    public class EditUserViewModel
    {
        public UserRole userRole { get; set; }
        public List<string> RoleTypes { get; set; }
    }
}
