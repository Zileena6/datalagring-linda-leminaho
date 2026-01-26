using EduCraft.Domain.Participants;

namespace EduCraft.Domain.Courses;

public class Competence
{
    public Competence(CompetenceId id, string expertise)
    {
        Id = id;
        Expertise = expertise;
    }

    private Competence() { }

    private readonly List<Instructor> _instructors = new();

    public CompetenceId Id { get; private set; } = null!;
    public string Expertise { get; private set; } = string.Empty;

    public virtual IReadOnlyCollection<Instructor> Instructors => _instructors.AsReadOnly();
}
