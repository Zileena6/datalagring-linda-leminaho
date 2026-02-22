using EduCraft.Domain.Entities.Participants;

namespace EduCraft.Domain.Interfaces;

public interface IParticipantQueries
{
    //Task<IEnumerable<Participant>> GetAllWithCourseAsync(CancellationToken ct);

    Task<IEnumerable<Student>> GetAllStudentsAsync(CancellationToken ct);

    Task<IEnumerable<Instructor>> GetAllInstructorsAsync(CancellationToken ct);

    Task<IEnumerable<Participant>> GetAllAsync(CancellationToken ct);
}
