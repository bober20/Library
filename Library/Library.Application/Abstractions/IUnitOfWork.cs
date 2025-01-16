namespace Library.Application.Abstractions;

public interface IUnitOfWork
{
    IBookRepository BookRepository { get; }
    IAuthorRepository AuthorRepository { get; }
    IGenreRepository GenreRepository { get; }
    IPasswordHasher PasswordHasher { get; }
    IUserRepository UserRepository { get; }
    IJwtProvider JwtProvider { get; }
    
    Task SaveAllAsync();
    Task DeleteDatabaseAsync();
    Task CreateDatabaseAsync();
}