using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Participants;

namespace EduCraft.Application.Services.Participants;

public class ParticipantService(IParticipantRepository repository, IParticipantQueries queries) : IParticipantService
{
    public async Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken cancellationToken)
    {
        var participant = Participant.Create(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            dto.PhoneNumber,
            dto.Role
            );

        await repository.CreateAsync(participant, cancellationToken);

        //return new ParticipantDTO
        //{
        //    Id = participant.Id.Value,
        //    FirstName = participant.FirstName,
        //    LastName = participant.LastName,
        //    Email = participant.Email,
        //    PhoneNumber = participant.PhoneNumber,
        //    Role = participant.Role,

        //};

        return MapToDTO([participant]).First();
    }

    public async Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync(CancellationToken cancellationToken)
    {
        var participants = await queries.GetAllAsync(cancellationToken);

        return MapToDTO(participants);
    }

    private static IEnumerable<ParticipantDTO> MapToDTO(IEnumerable<Participant> participants)
    {
        return participants.Select(p => p switch
        {
            Instructor i => new InstructorDTO
            {
                Id = i.Id.Value,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber,
                Role = i.Role,
            },
            _ => new ParticipantDTO
            {
                Id = p.Id.Value,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Role = p.Role,
            }
        }
        );
    }
}
