using EduCraft.Application.DTOs.Competences;
using EduCraft.Application.DTOs.Participants;

namespace EduCraft.Application.Interfaces;

public interface IParticipantService
{
    Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken ct);

    Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync(CancellationToken ct);

    Task<IEnumerable<ParticipantDTO>> GetAllStudentsAsync(CancellationToken ct);

    Task<IEnumerable<ParticipantDTO>> GetAllInstructorsAsync(CancellationToken ct);

    Task<ParticipantDTO> GetParticipantByIdAsync(Guid id, CancellationToken ct);

    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);

    Task<ParticipantDTO> UpdateParticipantAsync(
        Guid id,
        UpdateParticipantDTO dto,
        CancellationToken ct);

    Task AddCompetenceToInstructorAsync(
        AddCompetenceDTO dto, 
        CancellationToken ct);

    //Task AddCompetenceToInstructorAsync(AddCompetenceDTO dto, CancellationToken ct);

    Task DeleteParticipantAsync(Guid id, CancellationToken ct);
}
