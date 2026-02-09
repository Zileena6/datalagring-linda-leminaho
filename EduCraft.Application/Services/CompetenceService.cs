using EduCraft.Application.DTOs.Courses;
using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class CompetenceService(ICompetenceRepository competenceRepository) : ICompetenceService
{
    public async Task<CompetenceDTO> AddCompetenceAsync(AddCompetenceDTO dto, CancellationToken cancellationToken)
    {
        var competence = Competence.Create(
            dto.CompetenceName
            );

        await competenceRepository.AddAsync(competence, cancellationToken);

        return MapToDTO(competence);
    }

    public async Task<IEnumerable<CompetenceDTO>> GetAllCompetencesAsync(CancellationToken cancellationToken)
    {
        var competences = await competenceRepository.GetAllAsync(cancellationToken);

        return [.. competences.Select(MapToDTO)];
    }

    private static CompetenceDTO MapToDTO(Competence competence)
    {
        return new CompetenceDTO
        {
            Id = competence.Id,
            CompetenceName = competence.CompetenceName,
        };
    }
}
