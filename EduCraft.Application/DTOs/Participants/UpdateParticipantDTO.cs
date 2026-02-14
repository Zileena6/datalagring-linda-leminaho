using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Participants;

public record UpdateParticipantDTO
{
    //public Guid Id { get; init; }

    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string FirstName { get; init; } = string.Empty;

    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string LastName { get; init; } = string.Empty;

    [Required]
    [MinLength(5)]
    [MaxLength(150)]
    public string Email { get; init; } = string.Empty;

    public string? PhoneNumber { get; init; }

    [Required]
    public byte[] RowVersion { get; init; } = default!;
}
