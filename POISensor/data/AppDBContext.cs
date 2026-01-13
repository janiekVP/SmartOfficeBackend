using POISensor.models;
using Microsoft.EntityFrameworkCore;

namespace POISensor.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<POISensorModel> POISensors => Set<POISensorModel>();

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