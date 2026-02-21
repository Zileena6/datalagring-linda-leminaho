using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Primitives;

namespace EduCraft.Domain.Entities.Courses;

public class Competence : BaseEntity<CompetenceId>, IAggregateRoot
{
    public static Competence Create(
        string name
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        return new Competence(CompetenceId.New(), name);
    }

    public void Update(
        string competenceName    
    )
    {
        if (string.IsNullOrWhiteSpace(competenceName))
            throw new ArgumentException("Course name is required");

        CompetenceName = competenceName;

        UpdateTimeStamp();
    }

    protected Competence(CompetenceId id, string name)
    {
        Id = id;
        CompetenceName = name;
    }

    private Competence() { }

    private readonly List<Instructor> _instructors = new();

    public string CompetenceName { get; private set; } = string.Empty;

    public virtual IReadOnlyCollection<Instructor> Instructors => _instructors.AsReadOnly();

    //public void AddInstructor(Instructor instructor)
    //{
    //    ArgumentNullException.ThrowIfNull(instructor);

    //    if (!_instructors.Any(i => i.Id == instructor.Id))
    //    {
    //        _instructors.Add(instructor);
    //    }
    //}
}
