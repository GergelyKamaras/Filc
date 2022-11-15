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
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public List<Student> students { get; set; }
        public List<Teacher> Teachers { get; set; }

    }
}
