using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    /// <summary>
    /// RegisterUserViewModel used by the Register View.
    /// </summary>
    public class RegisterUserViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [Display(Name="Confirm Your Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords do not match!")]
        public string ConfirmedPassword { get; set; }
    }
}
