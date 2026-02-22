using EduCraft.Application.DTOs.Competences;
using System.Text.Json.Serialization;

namespace EduCraft.Application.DTOs.Participants;

public record InstructorDTO : ParticipantDTO
{
    [JsonPropertyOrder(100)]
    public List<CompetenceDTO> Competences { get; init; } = [];
}
