using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.ModelInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EFDataAccessLibrary.DataAccess
{
    
    public class ESContext : IdentityDbContext
    {
        public ESContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityUser>()
                .Ignore(p => p.PhoneNumber)
                .Ignore(p => p.PhoneNumberConfirmed)
                .Ignore(p => p.LockoutEnabled)
                .Ignore(p => p.LockoutEnd)
                .Ignore(p => p.TwoFactorEnabled) 
                .ToTable("Users", "Authetication");


            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles", "Authetication");

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles", "Authetication");
            
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins", "Authetication");

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims", "Authetication");
            
            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims", "Authetication");
            
            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens", "Authetication");


        }

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
