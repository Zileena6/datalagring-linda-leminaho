using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity, TId>(ApplicationDbContext context) where TEntity : BaseEntity<TId>, IAggregateRoot
{
    protected readonly ApplicationDbContext _context = context;

    public virtual async Task<bool> ExistsByIdAsync(TId id, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().AnyAsync(e => e.Id!.Equals(id), cancellationToken);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
        => await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id!.Equals(id), cancellationToken);

    public virtual async Task UpdateAsync(TEntity entity, byte[] rowVersion, CancellationToken cancellationToken)
    {
        _context.Entry(entity).Property("RowVersion").OriginalValue = rowVersion;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id!.Equals(id), cancellationToken);

        if (entity is null) return false;

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
