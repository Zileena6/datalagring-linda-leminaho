using EduCraft.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Participants;

public record CreateParticipantDTO
{
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string FirstName { get; init; } = string.Empty;

    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string LastName { get; init; } = string.Empty;

    [Required]
    [MinLength(1)]
    [MaxLength(150)]
    public string Email { get; init; } = string.Empty;

    [MinLength(1)]
    [MaxLength(20)]
    public string? PhoneNumber { get; init; }

    [Required]
    [MinLength(1)]
    [MaxLength(20)]
    public ParticipantRole Role { get; init; }
}
