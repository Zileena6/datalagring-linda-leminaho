using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Participants;

namespace EduCraft.Application.Services.Participants;

public class ParticipantService(IParticipantRepository repository, IParticipantQueries queries) : IParticipantService
{
    public async Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
