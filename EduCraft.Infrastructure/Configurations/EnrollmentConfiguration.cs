using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Entities.Participants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCraft.Infrastructure.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasConversion(
            enrollmentId => enrollmentId.Value,
            value => new EnrollmentId(value));

        builder.Property(e => e.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(e => e.StudentId).HasConversion(
            studentId => studentId.Value,
            value => new ParticipantId(value));

        builder.HasOne(e => e.Student)
            .WithMany()
            .HasForeignKey(e => e.StudentId);

        builder.Property(e => e.CourseInstanceId).HasConversion(
            courseInstanceId => courseInstanceId.Value,
            value => new CourseInstanceId(value));

        builder.HasOne(e => e.CourseInstance)
            .WithMany(e => e.Enrollments)
            .HasForeignKey(e => e.CourseInstanceId);

        builder.Property(e => e.RowVersion).IsRowVersion();
    }
}
