using Library.Core.Models;

namespace Library.Core.Abstractions;

public interface IGenreRepository
{
    Task<ResponseData<Genre>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ResponseData<IReadOnlyList<Genre>>> ListAllAsync(CancellationToken cancellationToken = default);
    
    Task AddAsync(Genre genre, CancellationToken cancellationToken = default);
}