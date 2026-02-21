using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity, TId>(ApplicationDbContext context) where TEntity : BaseEntity<TId>, IAggregateRoot
{
    protected readonly ApplicationDbContext _context = context;

    public virtual async Task<bool> ExistsByIdAsync(TId id, CancellationToken ct)
    {
        return await _context.Set<TEntity>().AnyAsync(e => e.Id!.Equals(id), ct);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        await _context.Set<TEntity>().AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct)
        => await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id!.Equals(id), ct);

    public virtual async Task UpdateAsync(TEntity entity, byte[]? rowVersion, CancellationToken ct)
    {
        if (rowVersion is null || rowVersion.Length == 0)
            throw new ArgumentException("RowVersion is required.", nameof(rowVersion));

        var entry = _context.Entry(entity);

        if (entry.State == EntityState.Detached)
            _context.Attach(entity);

        entry.Property("RowVersion").OriginalValue = rowVersion;

        await _context.SaveChangesAsync(ct);
    }

    public virtual async Task<bool> DeleteAsync(TId id, CancellationToken ct)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id!.Equals(id), ct);

        if (entity is null) return false;

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
