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

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? SchoolType { get; set; }
        public List<SchoolAdmin>? SchoolAdmin { get; set; }
        public List<Student>? Students { get; set; }
        public List<Subject>? Subjects { get; set; }
        public List<Lesson>? Lessons { get; set; }
        public List<Teacher>? Teachers { get; set; }
        public List<SchoolClass>? Classes { get; set; }
    }
}
