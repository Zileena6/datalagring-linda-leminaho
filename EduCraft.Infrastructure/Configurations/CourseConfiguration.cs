using EduCraft.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCraft.Infrastructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            c => c.Value,
            value => new CourseId(value));

        builder.Property(c => c.CourseCode)
            .IsRequired();

        builder.HasIndex(c => c.CourseCode)
            .IsUnique();

        builder.Property(c => c.CourseName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(200)
            .IsRequired();
    }
}
