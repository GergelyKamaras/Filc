using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public float Grade { get; set; }
        public string Description { get; set; }
        public Lesson Lesson { get; set; }
        public Subject Subject { get; set; }
        public DateTime Date { get; set; }
    }
}
