
using System.ComponentModel.DataAnnotations;

namespace Filc.ViewModel
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(30)]
        public string Role { get; set; }

        [Required]
        [MaxLength(200)]
        public string Salt { get; set; }
    }
}
