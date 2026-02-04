using EduCraft.Domain.Enums;

namespace EduCraft.Application.DTOs.Participants;

public record CreateParticipantDTO
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string? PhoneNumber { get; init; }
    public ParticipantRole Role { get; init; }
}
