using Microsoft.EntityFrameworkCore;

namespace MLWD5.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Song> Songs {  get; set; }
        public DbSet<Singer> Singers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Singer>()
                .HasMany(e => e.Songs)
                .WithOne(e => e.Singer)
                .HasForeignKey(e => e.SingerId)
                .IsRequired();
        }
    }
}
