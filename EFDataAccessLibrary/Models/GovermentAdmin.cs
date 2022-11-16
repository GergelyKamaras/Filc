using EFDataAccessLibrary.Models.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class GovermentAdmin : IUser
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
