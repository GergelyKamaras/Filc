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
    public class Parent 
    {
        public int Id { get; set; }

        [Required]
        public IdentityUser user { get; set; }
        
        public List<Student> Children { get; set; }
    }
}
