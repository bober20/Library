using Library.Core.Models;

namespace Library.Core.Abstractions;

public interface IGenreRepository
{
    Task<Genre> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Genre>> ListAllAsync(CancellationToken cancellationToken = default);
    
    Task<Genre> AddAsync(Genre genre, CancellationToken cancellationToken = default);
}