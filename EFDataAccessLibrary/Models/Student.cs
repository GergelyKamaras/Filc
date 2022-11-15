using EFDataAccessLibrary.Models.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Student : ISchoolMember
    {
        
        public int Id { get; set; }


        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string BirthDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        //TODO: encrypt password
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserRole { get; set; }

        public List<Lesson> Lessons { get; set; }

        
    }
}
