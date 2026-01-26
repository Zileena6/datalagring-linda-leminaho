using EduCraft.Domain.CourseInstances;
using EduCraft.Domain.Locations;

namespace EduCraft.Domain.Entities;

public class Location
{
    public Location(LocationId id, string name)
    {
        Id = id; 
        Name = name;
    }

    private Location() { }

    private readonly List<CourseInstance> _courseInstances = new();

    public LocationId Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;

    public virtual IReadOnlyCollection<CourseInstance> CourseInstances => _courseInstances.AsReadOnly();
}
