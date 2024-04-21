using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MLWD5.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Song> Songs {  get; set; }
        public DbSet<Singer> Singers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
