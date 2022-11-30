using EFDataAccessLibrary.Models.ModelInterfaces;
using Microsoft.AspNetCore.Identity;
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
        public ApplicationUser user { get; set; }

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

        public List<Lesson>? Lessons { get; set; }
        public List<Mark>? Marks { get; set; }

        [Required]
        public School School { get; set; }
        
    }
}
