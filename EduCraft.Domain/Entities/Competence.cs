using System;
using System.Collections.Generic;
using System.Text;

namespace EduCraft.Domain.Entities;

public class Competence
{
    public int Id { get; set; }
    public string Expertise { get; set; } = string.Empty;

    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
