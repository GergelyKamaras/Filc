
using System.ComponentModel.DataAnnotations;

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
    }
}
