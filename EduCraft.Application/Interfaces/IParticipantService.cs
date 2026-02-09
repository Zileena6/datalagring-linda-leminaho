using EduCraft.Application.DTOs.Participants;

namespace EduCraft.Application.Interfaces;

public interface IParticipantService
{
    Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync(CancellationToken cancellationToken);

    Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken cancellationToken);

    //  GetById, update, delete
}
