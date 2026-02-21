using EduCraft.Application.DTOs.Competences;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class CompetenceService(ICompetenceRepository repository) : ICompetenceService
{
    public async Task<CompetenceDTO> CreateCompetenceAsync(CreateCompetenceDTO dto, CancellationToken ct)
    {
        var competence = Competence.Create(
            dto.CompetenceName
            );

        await repository.AddAsync(competence, ct);

        return MapToDTO(competence);
    }

    public async Task<IEnumerable<CompetenceDTO>> GetAllCompetencesAsync(CancellationToken ct)
    {
        var competences = await repository.GetAllAsync(ct);

        return [.. competences.Select(MapToDTO)];
    }

    public async Task<CompetenceDTO> UpdateCompetenceAsync(
        Guid id, 
        UpdateCompetenceDTO dto, 
        CancellationToken ct
    )
    {
        var competenceId = new CompetenceId(id);

        var competence = await repository.GetByIdAsync(competenceId, ct) ??
            throw new ArgumentException($"Competence with id {id} was not found.");

        competence.Update(
            dto.CompetenceName    
        );

        await repository.UpdateAsync(competence, dto.RowVersion, ct);

        return MapToDTO(competence);
    }

    public async Task DeleteCompetenceAsync(Guid id, CancellationToken ct)
    {
        var competenceId = new CompetenceId(id);

        var deleted = await repository.DeleteAsync(competenceId, ct);

        if (!deleted)
            throw new ArgumentException($"Competence with id {id} was not found.");
    }

    private static CompetenceDTO MapToDTO(Competence competence)
    {
        return new CompetenceDTO
        {
            Id = competence.Id,
            CompetenceName = competence.CompetenceName,
            RowVersion = competence.RowVersion,
        };
    }
}
