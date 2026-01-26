using EduCraft.Domain.CourseInstances;
using EduCraft.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCraft.Infrastructure.Configurations
{
    public class CourseInstanceConfiguration : IEntityTypeConfiguration<CourseInstance>
    {
        public void Configure(EntityTypeBuilder<CourseInstance> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                id => id.Value,
                value => new CourseInstanceId(value));

            builder.HasOne(c => c.Course)
                .WithMany()
                .HasPrincipalKey(c => c.CourseCode)
                .HasForeignKey(c => c.CourseCode)
                .IsRequired();

            builder.Property(c => c.LocationId)
                .HasConversion(id => id.Value, value => new LocationId(value));

            builder.HasOne(c => c.Location)
                .WithMany()
                .HasForeignKey(c => c.LocationId)
                .IsRequired();

            builder.HasMany(c => c.Enrollments)
                .WithOne(c => c.CourseInstance)
                .HasForeignKey(c => c.CourseInstanceId);

            builder.Metadata.FindNavigation(nameof(CourseInstance.Enrollments))?
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(c => c.Instructors)
                .WithMany()
                .UsingEntity(j => j.ToTable("CourseInstanceInstructors"));

            builder.Metadata.FindNavigation(nameof(CourseInstance.Instructors))?
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(t => t.StartDate).IsRequired();
            builder.Property(t => t.EndDate).IsRequired();
            builder.Property(c => c.Capacity).IsRequired();
        }
    }
}
