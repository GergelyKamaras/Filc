using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace EFDataAccessLibrary.DataAccess
{
    public class ESContext : DbContext
    {
        public ESContext(DbContextOptions options) : base(options) { }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Parent> Parent { get; set; }



    }
}
