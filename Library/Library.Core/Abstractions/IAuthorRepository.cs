using Library.Core.Models;

namespace Library.Core.Abstractions;

public interface IAuthorRepository
{
    Task<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Author>> ListAllAsync(CancellationToken cancellationToken = default);
    
    Task AddAsync(Author entity, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(Author entity, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Author entity, CancellationToken cancellationToken = default);
}