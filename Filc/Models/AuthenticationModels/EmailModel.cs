using System.ComponentModel.DataAnnotations;

namespace Filc.Models.AuthenticationModels
{
    public class EmailModel
    {

        [Required]
        public string Email { get; set; }
    }
}
