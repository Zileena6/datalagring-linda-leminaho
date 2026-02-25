using EduCraft.Application.DTOs.Competences;
using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services.Participants;

public class ParticipantService(
    IParticipantRepository repository,
    IParticipantQueries queries,
    ICompetenceRepository competenceRepository
    ) : IParticipantService
{
    public async Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken ct)
    {
        var participant = Participant.Create(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            dto.PhoneNumber,
            dto.Role
            );

        await repository.AddAsync(participant, ct);

        return MapToDTO(participant);
    }
    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
    {
        return await repository.ExistsByEmailAsync(email, ct);
    }

    public async Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync(CancellationToken ct)
    {
        var participants = await queries.GetAllAsync(ct);

        return MapToDTOList(participants);
    }

    public async Task<IEnumerable<ParticipantDTO>> GetAllStudentsAsync(CancellationToken ct)
    {
        var students = await queries.GetAllStudentsAsync(ct);

        return MapToDTOList(students).OfType<StudentDTO>();
    }

    public async Task<IEnumerable<ParticipantDTO>> GetAllInstructorsAsync(CancellationToken ct)
    {
        var instructors = await queries.GetAllInstructorsAsync(ct);

        return MapToDTOList(instructors);
    }

    public async Task<ParticipantDTO> GetParticipantByIdAsync(Guid id, CancellationToken ct)
    {
        var participantId = new ParticipantId(id);

        var participant = (Participant?)await repository.GetInstructorWithCompetenceAsync(participantId, ct)
            ?? await repository.GetByIdAsync(participantId, ct)
            ?? throw new ArgumentException($"Participant with id {id} was not found.");

        return MapToDTO(participant);
    }

    public async Task<ParticipantDTO> UpdateParticipantAsync(
        Guid id,
        UpdateParticipantDTO dto,
        CancellationToken ct)
    {
        var participantId = new ParticipantId(id);

        var participant = await repository.GetByIdAsync(participantId, ct) ??
        throw new ArgumentException($"Participant with id {id} was not found.");

        if (dto.Email != null && participant.Email != dto.Email)
        {
            var exists = await repository.ExistsByEmailAsync(dto.Email, ct);
            if (exists)
                throw new InvalidOperationException("Email already exists");
        }

        participant.Update(
            dto.FirstName ?? string.Empty,
            dto.LastName ?? string.Empty,
            dto.Email ?? string.Empty,
            dto.PhoneNumber
        );

        await repository.UpdateAsync(participant, dto.RowVersion, ct);

        return MapToDTO(participant);
    }

    public async Task AddCompetenceToInstructorAsync(
    AddCompetenceDTO dto,
    CancellationToken ct)
    {
        var instructor = await repository.GetInstructorWithCompetenceAsync(
            new ParticipantId(dto.ParticipantId), ct)
            ?? throw new ArgumentException("Instructor not found");

        var competence = await competenceRepository.GetByIdAsync(
            new CompetenceId(dto.CompetenceId), ct)
            ?? throw new ArgumentException("Competence not found");

        instructor.AddCompetence(competence);

        var rowVersionBytes = Convert.FromBase64String(dto.RowVersion);
        await repository.UpdateAsync(instructor, rowVersionBytes, ct);
    }


    //public async Task AddCompetenceToInstructorAsync(AddCompetenceDTO dto, CancellationToken ct)
    //{
    //    await AddCompetenceToInstructorAsync(dto.InstructorId, dto.CompetenceId, ct);
    //}

    public async Task DeleteParticipantAsync(Guid id, CancellationToken ct)
    {
        var participantId = new ParticipantId(id);

        var deleted = await repository.DeleteAsync(participantId, ct);

        if (!deleted)
            throw new ArgumentException($"Participant with id {id} was not found.");
    }

    public static ParticipantDTO MapToDTO(Participant p)
    {
        return p switch
        {
            Instructor i => new InstructorDTO
            {
                Id = i.Id.Value,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber,
                Role = i.Role,
                RowVersion = i.RowVersion,
                CreatedAt = p.CreatedAt,
                Competences = [.. i.Competences.Select(c => new CompetenceDTO
                {
                    Id = c.Id.Value,
                    CompetenceName = c.CompetenceName,
                    RowVersion = c.RowVersion
                })]
            },

            _ => new StudentDTO
            {
                Id = p.Id.Value,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Role = p.Role,
                RowVersion = p.RowVersion,
                CreatedAt = p.CreatedAt,
                //Enrollments = p.Enrollments.Select(e => new EnrollmentDTO
                //{
                //    Id = e.Id.Value,
                //    Status = e.Status.ToString(),
                //    CourseInstanceId = e.CourseInstanceId.Value,
                //    //CourseCode = e.CourseInstance.CourseCode,
                //    //StartDate = e.CourseInstance.StartDate,
                //    //EndDate = e.CourseInstance.EndDate
                //}).ToList()
            }
        };
    }

    public static IEnumerable<ParticipantDTO> MapToDTOList(IEnumerable<Participant> participants)
    {
        return participants.Select(MapToDTO);
    }
}
