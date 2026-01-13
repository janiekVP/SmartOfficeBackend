using SensorData.models;
using Microsoft.EntityFrameworkCore;

namespace SensorData.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<SensorDataModel> SensorData => Set<SensorDataModel>();

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