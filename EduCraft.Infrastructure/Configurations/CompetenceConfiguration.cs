using EduCraft.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCraft.Infrastructure.Configurations;

public class CompetenceConfiguration : IEntityTypeConfiguration<Competence>
{
    public void Configure(EntityTypeBuilder<Competence> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            competenceId => competenceId.Value,
            value => new CompetenceId(value));

        builder.Property(c => c.CompetenceName)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasMany(c => c.Instructors)
            .WithMany(c => c.Competences)
            .UsingEntity(j => j.ToTable("InstructorCompetence"));

        builder.Metadata.FindNavigation(nameof(Competence.Instructors))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(c => c.RowVersion).IsRowVersion();
    }
}
