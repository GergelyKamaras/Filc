using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EFDataAccessLibrary.DataAccess
{
    public class ESContext : IdentityDbContext
    {
        public ESContext(DbContextOptions options) : base(options) { }
        public DbSet<GovernmentAdmin> GovernmentAdmin { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<SchoolAdmin> SchoolAdmin { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Mark> Mark { get; set; }
    }
}
