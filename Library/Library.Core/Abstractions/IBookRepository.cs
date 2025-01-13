using System.Linq.Expressions;
using Library.Core.Models;

namespace Library.Core.Abstractions;

public interface IBookRepository
{
    Task<ResponseData<Book>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ResponseData<IReadOnlyList<Book>>> ListAllAsync(CancellationToken cancellationToken = default);

    Task<ResponseData<IReadOnlyList<Book>>> ListAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default);
    
    Task<ResponseData<ListModel<Book>>> ListAllAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default);

    Task<ResponseData<ListModel<Book>>> ListAsync(int pageNo, int pageSize, Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default);

    Task AddAsync(Book entity, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(Guid id, Book entity, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ResponseData<Book>> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter,
        CancellationToken cancellationToken = default);
}