using Microsoft.EntityFrameworkCore;

namespace AppOne.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Class> Classs { get; set; }
        public DbSet<Studnt> Studnts { get; set; }
    }
}
