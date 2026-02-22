using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Enums;

namespace EduCraft.Domain.Entities.Participants;

public class Student : Participant
{
    internal Student(
        ParticipantId id, 
        string firstName, 
        string lastName, 
        string email, 
        string? phoneNumber
    ) : base(id, firstName, lastName, email, phoneNumber, ParticipantRole.Student) { }

    private Student() : base() { }

    private readonly List<Enrollment> _enrollments = new();
    public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();
}
