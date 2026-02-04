using EduCraft.Application.DTOs.Courses;
using System.Text.Json.Serialization;

namespace EduCraft.Application.DTOs.Participants;

public record InstructorDTO : ParticipantDTO
{
    [JsonPropertyOrder(100)]
    public List<CompetenceDTO> Comptetences { get; init; } = [];
}
