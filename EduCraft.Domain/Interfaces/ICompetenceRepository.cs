using EduCraft.Domain.Entities.Courses;

namespace EduCraft.Domain.Interfaces;

public interface ICompetenceRepository : IBaseRepository<Competence, CompetenceId>
{
    Task<bool> ExistsByCompetenceName(string CompetenceName, CancellationToken ct);
}
