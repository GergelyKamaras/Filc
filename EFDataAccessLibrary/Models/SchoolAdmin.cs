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
    public class SchoolAdmin : ISchoolMember
    {
        public int Id { get; set; }

        [Required]
        public IdentityUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        
        public School School { get; set; }

    }
}
