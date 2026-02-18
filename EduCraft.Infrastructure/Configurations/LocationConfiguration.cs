using EduCraft.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCraft.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id).HasConversion(
            id => id.Value,
            value => new LocationId(value));

        builder.Property(l => l.LocationName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(l => l.RowVersion).IsRowVersion();
    }
}
