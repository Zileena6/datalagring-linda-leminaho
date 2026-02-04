using EduCraft.Domain.Participants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCraft.Infrastructure.Configurations;

public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            participantId => participantId.Value,
            value => new ParticipantId(value));

        builder.Property(p => p.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.LastName) 
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Email).HasMaxLength(150);

        builder.HasIndex(p => p.Email).IsUnique();

        builder.Property(p => p.PhoneNumber).HasMaxLength(20);

        builder.Property(p => p.Role)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.RowVersion).IsRowVersion();
    }
}
