using Library.Application.Abstractions;

namespace Library.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _dbContext;
    
    private readonly Lazy<IGenreRepository> _genreRepository;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<IAuthorRepository> _authorRepository;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IPasswordHasher> _passwordHasher;
    private readonly Lazy<IJwtProvider> _jwtProvider;
    
    public UnitOfWork(LibraryDbContext dbContext, 
        IGenreRepository genreRepository, 
        IBookRepository bookRepository, 
        IAuthorRepository authorRepository,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _dbContext = dbContext;
        
        _genreRepository = new Lazy<IGenreRepository>(() => genreRepository);
        _bookRepository = new Lazy<IBookRepository>(() => bookRepository);
        _authorRepository = new Lazy<IAuthorRepository>(() => authorRepository);
        _userRepository = new Lazy<IUserRepository>(() => userRepository);

        _passwordHasher = new Lazy<IPasswordHasher>(() => passwordHasher);
        _jwtProvider = new Lazy<IJwtProvider>(() => jwtProvider);
    }
    
    public IGenreRepository GenreRepository => _genreRepository.Value;
    public IBookRepository BookRepository => _bookRepository.Value;
    public IAuthorRepository AuthorRepository => _authorRepository.Value;
    public IUserRepository UserRepository => _userRepository.Value;
    public IPasswordHasher PasswordHasher => _passwordHasher.Value;
    public IJwtProvider JwtProvider => _jwtProvider.Value;
    
    public async Task SaveAllAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDatabaseAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
    }

    public async Task CreateDatabaseAsync()
    {
        await _dbContext.Database.EnsureCreatedAsync();
    }
}