using EduCraft.Domain.CourseInstances;
using EduCraft.Domain.Courses;
using EduCraft.Domain.Enums;

namespace EduCraft.Domain.Participants;

public class Instructor : Participant
{
    public Instructor(ParticipantId id, string firstName, string lastName, string email, string? phoneNumber) : base(id, firstName, lastName, email, phoneNumber, ParticipantRole.Instructor) { }

    private Instructor() : base() { }

    private readonly List<Competence> _competences = new();
    private readonly List<CourseInstance> _courseInstances = new();

    public virtual IReadOnlyCollection<Competence> Competences => _competences.AsReadOnly();
    public virtual IReadOnlyCollection<CourseInstance> CourseInstances => _courseInstances.AsReadOnly();
}
