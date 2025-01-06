namespace Library.DataAccess.Repositories;

public class BookRepository : IBookRepository
{
    private LibraryDbContext _dbContext;
    private IMapper _mapper;

    public BookRepository(LibraryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bookEntity = await _dbContext.Books.FindAsync(id, cancellationToken);
        return _mapper.Map<BookEntity, Book>(bookEntity);
    }

    public async Task<IReadOnlyList<Book>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        var bookEntities = await _dbContext.Books.ToListAsync(cancellationToken);
        return bookEntities.Select(b => _mapper.Map<BookEntity, Book>(b)).ToList();
    }

    public async Task<IReadOnlyList<Book>> ListAsync(Expression<Func<Book, bool>> filter, 
        CancellationToken cancellationToken = default)
    {
        var bookEntities = await _dbContext.Books.ToListAsync(cancellationToken);
        var books = await bookEntities.Select(b => _mapper.Map<BookEntity, Book>(b))
            .AsQueryable()
            .Where(filter)
            .ToListAsync(cancellationToken);

        return books;
    }

    public async Task AddAsync(Book entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Books.AddAsync(_mapper.Map<Book, BookEntity>(entity), cancellationToken);
    }

    public async Task UpdateAsync(Book entity, CancellationToken cancellationToken = default)
    {
        var bookEntity = _mapper.Map<Book, BookEntity>(entity);
        _dbContext.Update(bookEntity);
    }

    public async Task DeleteAsync(Book entity, CancellationToken cancellationToken = default)
    {
        var bookEntity = _mapper.Map<Book, BookEntity>(entity);
        _dbContext.Remove(bookEntity);
    }

    public async Task<Book> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Books.Select(b => _mapper.Map<BookEntity, Book>(b))
            .AsQueryable()
            .FirstAsync(filter, cancellationToken);
    }
}