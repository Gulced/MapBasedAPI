using MapBasedAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;

namespace MapBasedAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MapPoint> MapPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Eğer gerekirse özel konfigürasyonlar burada yapılabilir
            // Örneğin:
            // modelBuilder.Entity<MapPoint>().Property(m => m.Location).HasSrid(4326);
        }
    }
}
