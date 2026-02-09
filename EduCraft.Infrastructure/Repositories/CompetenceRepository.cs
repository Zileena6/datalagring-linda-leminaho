using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Infrastructure.Repositories;

public class CompetenceRepository(ApplicationDbContext context) : BaseRepository<Competence, CompetenceId>(context), ICompetenceRepository
{
    public Task<bool> ExistsByCompetenceName(string CompetenceName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
