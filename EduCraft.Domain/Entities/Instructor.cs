using System;
using System.Collections.Generic;
using System.Text;

namespace EduCraft.Domain.Entities;

public class Instructor : Participant
{
    public ICollection<Competence> Competences { get; set; } = new List<Competence>();
    public ICollection<CourseInstance> Instances { get; set; } = new List<CourseInstance>();
}
