using EduCraft.Domain.CourseInstances;

namespace EduCraft.Domain.Locations;

public class Location
{
    public Location(LocationId id, string name)
    {
        Id = id; 
        Name = name;
    }

    private Location() { }

    public LocationId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    public byte[] RowVersion { get; private set; } = null!;

}
