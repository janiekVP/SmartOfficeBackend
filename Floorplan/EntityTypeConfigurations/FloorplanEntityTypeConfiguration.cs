using Floorplan.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Floorplan.EntityTypeConfigurations
{
       public class FloorplanModelConfiguration : IEntityTypeConfiguration<FloorplanModel>
       {
              public void Configure(EntityTypeBuilder<FloorplanModel> builder)
              {
                     builder.ToTable("Floorplans");
                     
                     builder.HasKey(f => f.Id);
                     
                     builder.Property(f => f.Country)
                            .IsRequired()
                            .HasMaxLength(100);

                     builder.Property(f => f.District)
                            .IsRequired()
                            .HasMaxLength(100);

                     builder.Property(f => f.City)
                            .IsRequired()
                            .HasMaxLength(100);

                     builder.Property(f => f.Company)
                            .IsRequired()
                            .HasMaxLength(150);

                     builder.Property(f => f.Office)
                            .IsRequired()
                            .HasMaxLength(150);

                     builder.Property(f => f.Floor)
                            .IsRequired()
                            .HasMaxLength(50);
                     
                     builder.Property(f => f.Image)
                            .HasColumnType("bytea");

                     builder.Property(f => f.ImageContentType)
                            .HasMaxLength(100);
              }
       }
}
