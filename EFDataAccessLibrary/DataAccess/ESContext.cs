using FilcDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace FilcDataAccessLibrary.DataAccess
{
    public class ESContext : DbContext
    {
        public ESContext(DbContextOptions options) : base(options) { }
        public DbSet<Teacher> Teacher { get; set; }

    }
}
