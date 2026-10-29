using Microsoft.EntityFrameworkCore;

namespace nilakhas_collection.Models
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<adminlogin> adminlogins { get; set; }

        public DbSet<neworderformki> createneworders { get; set; }

        public DbSet<workerssignup> workersignups { get; set; }
    }
}
