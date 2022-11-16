using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Mark
    {
        public int Id { get; set; }
        
        [Required]
        public Teacher Teacher { get; set; }
        
        [Required]
        public Student Student { get; set; }
        
        [Required]
        [MaxLength(5)]
        public float Grade { get; set; }
        
        [Required]
        [MinLength(20),MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public Lesson Lesson { get; set; }
        
        [Required]
        public Subject Subject { get; set; }
        
        [Required]
        [Timestamp]
        public DateTime Date { get; set; }
    }
}
