using Library.Core.Models;

namespace Library.Core.Abstractions;

public interface IUnitOfWork
{
    IBookRepository BookRepository { get; }
    IAuthorRepository AuthorRepository { get; }
    IGenreRepository GenreRepository { get; }
    
    Task SaveAllAsync();
    Task DeleteDatabaseAsync();
    Task CreateDatabaseAsync();
}