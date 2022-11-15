
using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models.ModelInterfaces;

namespace EFDataAccessLibrary.Models
{
    public class Teacher : ISchoolMember
    {
        [Required]
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
        public List<Subject> Subjects { get; set; }
        public List<Lesson> Lessons{ get; set; }
        public School School { get; set; }
    }
}
