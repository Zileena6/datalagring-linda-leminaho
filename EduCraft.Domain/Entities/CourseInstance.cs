using System;
using System.Collections.Generic;
using System.Text;

namespace EduCraft.Domain.Entities;

public class CourseInstance
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Capacity {  get; set; }

    public required string CourseCode { get; set; }
    public Course Course { get; set; } = null!;

    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;

    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();


    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    //public bool IsFull => Enrollments.Count >= Capacity;
}
