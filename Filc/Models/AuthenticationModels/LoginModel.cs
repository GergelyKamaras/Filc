
using System.ComponentModel.DataAnnotations;

namespace Filc.ViewModel
{
    public class LoginModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }


        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        [Required]
        public string Role { get; set; }


    }
}
