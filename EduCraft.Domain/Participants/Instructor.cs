using EduCraft.Domain.Courses;
using EduCraft.Domain.Enums;

namespace EduCraft.Domain.Participants;

public class Instructor : Participant
{
    internal Instructor(ParticipantId id, string firstName, string lastName, string email, string? phoneNumber) : base(id, firstName, lastName, email, phoneNumber, ParticipantRole.Instructor) { }

    private Instructor() : base() { }

    private readonly List<Competence> _competences = new();


    public virtual IReadOnlyCollection<Competence> Competences => _competences.AsReadOnly();
   
}
