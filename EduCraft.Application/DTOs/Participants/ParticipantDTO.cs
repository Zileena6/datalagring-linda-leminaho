using EduCraft.Domain.Enums;
using System.Text.Json.Serialization;

namespace EduCraft.Application.DTOs.Participants;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(ParticipantDTO), "student")]
[JsonDerivedType(typeof(InstructorDTO), "instructor")]
public record ParticipantDTO
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string? PhoneNumber { get; init; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ParticipantRole Role { get; init; }
}
