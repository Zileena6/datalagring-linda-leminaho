namespace EduCraft.Application.DTOs.Competences;

public record AddCompetenceDTO
{
    public Guid ParticipantId { get; init; }
    public Guid CompetenceId { get; init; }
    public string RowVersion { get; init; } = default!;
}
