using EduCraft.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduCraft.Domain.Entities;

public class Enrollment
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt {  get; set; } = DateTime.UtcNow;
    public EnrollmentStatus Status { get; set; }

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int CourseInstanceId { get; set; }
    public CourseInstance CourseInstance { get; set; } = null!;
}
