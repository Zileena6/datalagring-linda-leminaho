using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Primitives;

namespace EduCraft.Domain.Entities.Locations;

public class Location : BaseEntity<LocationId>, IAggregateRoot
{
    public static Location Create(
        string name
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        return new Location(LocationId.New(), name);
    }

    public void Update(
        string name    
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Location name is required");

        LocationName = name;

        UpdateTimeStamp();
    }

    protected Location(LocationId id, string name)
    {
        Id = id; 
        LocationName = name;
    }

    private Location() { }

    public string LocationName { get; private set; } = string.Empty;
}
