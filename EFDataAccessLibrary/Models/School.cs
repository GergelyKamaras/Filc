using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class School
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string SchoolType { get; set; }

        [Required]
        public SchoolAdmin SchoolAdmin { get; set; }

        [Required]
        public List<Student> Students { get; set; }

        [Required]
        public List<Subject> Subjects { get; set; }

        [Required]
        public List<Lesson> Lessons { get; set; }
        
        [Required]
        public List<Teacher> Teachers { get; set; }

        [Required]
        public List<SchoolClass> Classes { get; set; }
    }
}
