using System;
using System.Collections.Generic;
using System.Text;

namespace EduCraft.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<CourseInstance> Instances { get; set; } = new List<CourseInstance>();

}
