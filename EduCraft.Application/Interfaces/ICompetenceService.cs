using EduCraft.Application.DTOs.Competences;

namespace EduCraft.Application.Interfaces;

public interface ICompetenceService
{
    Task<CompetenceDTO> CreateCompetenceAsync(CreateCompetenceDTO dto, CancellationToken ct);

    Task<IEnumerable<CompetenceDTO>> GetAllCompetencesAsync(CancellationToken ct);

    Task<CompetenceDTO> UpdateCompetenceAsync(
        Guid id, 
        UpdateCompetenceDTO dto, 
        CancellationToken ct);

    Task DeleteCompetenceAsync(Guid id, CancellationToken ct);
}
