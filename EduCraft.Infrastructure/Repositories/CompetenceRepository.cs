using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public class CompetenceRepository(ApplicationDbContext context) : BaseRepository<Competence, CompetenceId>(context), ICompetenceRepository
{
    public async Task<bool> ExistsByCompetenceName(string competenceName, CancellationToken cancellationToken) =>
        await _context.Competences.AnyAsync(c => c.CompetenceName == competenceName, cancellationToken);
}
