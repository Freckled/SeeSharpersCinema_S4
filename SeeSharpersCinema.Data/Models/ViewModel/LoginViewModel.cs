using System.ComponentModel.DataAnnotations;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    /// <summary>
    /// LoginViewModel used by the Login View.
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
