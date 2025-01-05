using System.Linq.Expressions;
using Library.Core.Models;

namespace Library.Core.Abstractions;

public interface IBookRepository
{
    Task GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Book>> ListAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Book>> ListAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default);

    Task AddAsync(Book entity, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(Book entity, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Book entity, CancellationToken cancellationToken = default);
    
    Task FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default);
}