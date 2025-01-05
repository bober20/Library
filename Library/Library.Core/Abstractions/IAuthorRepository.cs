using Library.Core.Models;

namespace Library.Core.Abstractions;

public interface IAuthorRepository
{
    Task GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Author>> ListAllAsync(CancellationToken cancellationToken = default);
    
    Task AddAsync(Book entity, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(Book entity, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Book entity, CancellationToken cancellationToken = default);
}