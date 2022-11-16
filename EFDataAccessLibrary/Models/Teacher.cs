
using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models.ModelInterfaces;
using Microsoft.AspNetCore.Identity;

namespace EFDataAccessLibrary.Models
{
    public class Teacher : ISchoolMember
    {
        public int Id { get; set; }

        [Required]
        public IdentityUser user { get; set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [Timestamp]
        public DateTime BirthDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        public List<Subject>? Subjects { get; set; }
        public List<Lesson>? Lessons{ get; set; }

        [Required]
        public School School { get; set; }
    }
}
