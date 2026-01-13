using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensorData.models;

namespace SensorData.EntityTypeConfigurations
{
    public class SensorDataModelConfiguration : IEntityTypeConfiguration<SensorDataModel>
    {
        public void Configure(EntityTypeBuilder<SensorDataModel> builder)
        {
            builder.ToTable("SensorData");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.Battery)
                .IsRequired();
            
            builder.Property(p => p.Temperature)
                .IsRequired();
            
            builder.Property(p => p.Noise)
                .IsRequired();
            
            builder.Property(p => p.Light)
                .IsRequired();
            
            builder.Property(p => p.Co2)
                .IsRequired();
            
            builder.Property(p => p.LastComDate)
                .IsRequired();
            

            builder.HasIndex(p => p.POISensorId)
                .HasDatabaseName("IX_SensorData_POISensorId");
            
            builder.HasIndex(s => s.LastComDate)
                .HasDatabaseName("IX_SensorData_LastComDate");

            builder.HasIndex(s => new { s.POISensorId, s.LastComDate })
                .HasDatabaseName("IX_SensorData_POISensorId_LastComDate");

        }
    }
}