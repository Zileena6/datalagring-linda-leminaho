using EduCraft.Domain.CourseInstances;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduCraft.Domain.Participants;

public class Student : Participant
{
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
