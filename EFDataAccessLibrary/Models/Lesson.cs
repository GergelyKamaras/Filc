using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public Subject Subject { get; set; }

        [Required]
        public List<Student> students { get; set; }

        [Required]
        public List<Teacher> Teachers { get; set; }

        [Required]
        public School School { get; set; }

        
    }
}
