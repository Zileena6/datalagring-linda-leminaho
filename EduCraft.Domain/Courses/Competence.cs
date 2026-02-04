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

    public CompetenceId Id { get; private set; }
    public string Expertise { get; private set; } = string.Empty;

    public byte[] RowVersion { get; private set; } = null!;

    public virtual IReadOnlyCollection<Instructor> Instructors => _instructors.AsReadOnly();

    public void AddInstructor(Instructor instructor)
    {
        ArgumentNullException.ThrowIfNull(instructor);

        if (!_instructors.Any(i => i.Id == instructor.Id))
        {
            _instructors.Add(instructor);
        }
    }
}
