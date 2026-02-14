using EduCraft.Application.DTOs.Participants;

namespace EduCraft.Application.Interfaces;

public interface IParticipantService
{
    Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken cancellationToken);

    Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync(CancellationToken cancellationToken);

    Task<ParticipantDTO> GetParticipantByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);

    Task<ParticipantDTO> UpdateParticipantAsync(
        Guid id,
        UpdateParticipantDTO dto,
        CancellationToken cancellationToken);

    Task DeleteParticipantAsync(Guid id, CancellationToken cancellationToken);
}
