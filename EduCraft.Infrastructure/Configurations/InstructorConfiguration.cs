using EduCraft.Domain.Participants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCraft.Infrastructure.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasMany(i => i.Competences)
            .WithMany(c => c.Instructors)
            .UsingEntity(j => j.ToTable("InstructorCompetence"));

        builder.Metadata.FindNavigation(nameof(Instructor.Competences))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
