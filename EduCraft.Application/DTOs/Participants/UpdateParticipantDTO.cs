using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Participants;

public record UpdateParticipantDTO
{
    [MaxLength(50)]
    public string FirstName { get; init; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; init; } = string.Empty;

    [MaxLength(150)]
    public string Email { get; init; } = string.Empty;

    public string? PhoneNumber { get; init; }

    public byte[]? RowVersion { get; init; }
}
