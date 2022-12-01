using System.ComponentModel.DataAnnotations;

namespace Filc.Models.AuthenticationModels
{
    public class EmailModel
    {

        [EmailAddress]
        public string Email { get; set; }
    }
}
