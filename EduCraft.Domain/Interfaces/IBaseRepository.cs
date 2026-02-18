namespace EduCraft.Domain.Interfaces;

public interface IBaseRepository<T, TId>
{
    Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, byte[]? rowVersion, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
}