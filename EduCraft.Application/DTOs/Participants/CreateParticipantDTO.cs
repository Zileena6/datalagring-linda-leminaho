using EduCraft.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Participants;

public record CreateParticipantDTO
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; init; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; init; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Email { get; init; } = string.Empty;

    [MaxLength(20)]
    public string? PhoneNumber { get; init; }

    public ParticipantRole Role { get; init; }
}
