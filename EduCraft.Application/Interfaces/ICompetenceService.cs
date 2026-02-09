using EduCraft.Application.DTOs.Courses;
using EduCraft.Application.DTOs.Participants;

namespace EduCraft.Application.Interfaces;

public interface ICompetenceService
{
    Task<IEnumerable<CompetenceDTO>> GetAllCompetencesAsync(CancellationToken cancellationToken);

    Task<CompetenceDTO> AddCompetenceAsync(AddCompetenceDTO dto, CancellationToken cancellationToken);

    // GetById, update, delete
}
