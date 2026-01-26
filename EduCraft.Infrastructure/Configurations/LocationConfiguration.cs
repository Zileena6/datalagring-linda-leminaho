
using EduCraft.Domain.Entities;
using EduCraft.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCraft.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id).HasConversion(
            locationId => locationId.Value,
            value => new LocationId(value));

        builder.Property(l => l.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
