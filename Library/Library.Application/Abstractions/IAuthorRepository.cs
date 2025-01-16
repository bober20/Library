namespace Library.Application.Abstractions;

public interface IAuthorRepository
{
    Task<ResponseData<Author>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ResponseData<IReadOnlyList<Author>>> ListAllAsync(CancellationToken cancellationToken = default);
    
    Task AddAsync(Author entity, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(Author entity, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Author entity, CancellationToken cancellationToken = default);
    
    Task<ResponseData<IReadOnlyList<Book>>> GetAllAuthorBooks(Guid id, CancellationToken cancellationToken = default);

    Task<ResponseData<ListModel<Book>>> GetAllAuthorBooks(Guid id, int pageNo, int pageSize,
        CancellationToken cancellationToken = default);

}