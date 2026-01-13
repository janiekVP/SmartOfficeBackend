using POI.models;
using Microsoft.EntityFrameworkCore;

namespace POI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<POIModel> POIs => Set<POIModel>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}