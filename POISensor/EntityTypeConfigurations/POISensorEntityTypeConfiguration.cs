using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POISensor.models;

namespace POISensor.EntityTypeConfigurations
{
    public class POISensorModelConfiguration : IEntityTypeConfiguration<POISensorModel>
    {
        public void Configure(EntityTypeBuilder<POISensorModel> builder)
        {
            builder.ToTable("POISensors");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100);

            builder.Property(p => p.Type)
                .HasMaxLength(100);
            

            builder.HasIndex(p => p.POIId)
                .HasDatabaseName("IX_POISensors_POIId");
        }
    }
}