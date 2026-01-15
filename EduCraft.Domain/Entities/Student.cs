using System;
using System.Collections.Generic;
using System.Text;

namespace EduCraft.Domain.Entities;

public class Student : Participant
{
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
