using EduCraft.Application.DTOs.Competences;

namespace EduCraft.Application.Interfaces;

public interface ICompetenceService
{
    Task<CompetenceDTO> AddCompetenceAsync(AddCompetenceDTO dto, CancellationToken cancellationToken);

    Task<IEnumerable<CompetenceDTO>> GetAllCompetencesAsync(CancellationToken cancellationToken);

    Task<CompetenceDTO> UpdateCompetenceAsync(
        Guid id, 
        UpdateCompetenceDTO dto, 
        CancellationToken cancellationToken);

    Task DeleteCompetenceAsync(Guid id, CancellationToken cancellationToken);
}
