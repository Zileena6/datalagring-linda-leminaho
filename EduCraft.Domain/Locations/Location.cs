using EduCraft.Domain.CourseInstances;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduCraft.Domain.Entities;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<CourseInstance> CourseInstances { get; set; } = new List<CourseInstance>();
}
