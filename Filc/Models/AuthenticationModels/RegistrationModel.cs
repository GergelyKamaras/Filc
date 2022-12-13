
using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models;

namespace Filc.ViewModel
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(30)]
        public string Role { get; set; }

        [Required]
        [MaxLength(200)]
        public string Salt { get; set; }

        public RegistrationModel(ApplicationUser user, string role)
        {
            Email = user.Email;
            Password = user.PasswordHash;
            Salt = user.Salt;
            Role = role;
        }
    }
}
