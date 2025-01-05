namespace Library.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _dbContext;
    
    private readonly Lazy<IGenreRepository> _genreRepository;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<IAuthorRepository> _authorRepository;
    
    public UnitOfWork(LibraryDbContext dbContext, IGenreRepository genreRepository, IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _dbContext = dbContext;
        
        _genreRepository = new Lazy<IGenreRepository>(() => genreRepository);
        _bookRepository = new Lazy<IBookRepository>(() => bookRepository);
        _authorRepository = new Lazy<IAuthorRepository>(() => authorRepository);
    }
    
    public IGenreRepository GenreRepository => _genreRepository.Value;
    public IBookRepository BookRepository => _bookRepository.Value;
    public IAuthorRepository AuthorRepository => _authorRepository.Value;
    
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