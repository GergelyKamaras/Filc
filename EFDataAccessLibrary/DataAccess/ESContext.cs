using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace EFDataAccessLibrary.DataAccess
{
    public class ESContext : DbContext
    {
        public ESContext(DbContextOptions options) : base(options) { }
        public DbSet<Teacher> Teacher { get; set; }

    }
}
