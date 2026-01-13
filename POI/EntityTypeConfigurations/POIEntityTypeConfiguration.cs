using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POI.models;

namespace POI.EntityTypeConfigurations
{
    public class POIModelConfiguration : IEntityTypeConfiguration<POIModel>
    {
        public void Configure(EntityTypeBuilder<POIModel> builder)
        {
            builder.ToTable("POIs");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100);

            builder.Property(p => p.Type)
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(250);

            builder.Property(p => p.CoordX);

            builder.Property(p => p.CoordY);


            builder.HasIndex(p => p.FloorplanId)
                .HasDatabaseName("IX_POIs_FloorplanId");
        }
    }
}