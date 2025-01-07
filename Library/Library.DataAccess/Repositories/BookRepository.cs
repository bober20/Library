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
        var bookEntities = await _dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
        return bookEntities.Select(b => _mapper.Map<BookEntity, Book>(b)).ToList();
    }

    public async Task<IReadOnlyList<Book>> ListAsync(Expression<Func<Book, bool>> filter, 
        CancellationToken cancellationToken = default)
    {
        var bookEntities = await _dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
        var books = await bookEntities.Select(b => _mapper.Map<BookEntity, Book>(b))
            .AsQueryable()
            .Where(filter)
            .ToListAsync(cancellationToken);

        return books;
    }

    public async Task AddAsync(Book entity, CancellationToken cancellationToken = default)
    {
        var bookEntity = _mapper.Map<Book, BookEntity>(entity);
        _dbContext.Authors.Attach(bookEntity.Author);
        _dbContext.Genres.Attach(bookEntity.Genre);
        
        await _dbContext.Books.AddAsync(bookEntity, cancellationToken);
        
        // var genreEntity = await _dbContext.Genres.FindAsync(entity.Genre.Id, cancellationToken);
        // var authorEntity = await _dbContext.Authors.FindAsync(entity.Author.Id, cancellationToken);
        //
        // bookEntity.Author = authorEntity;
        // bookEntity.Genre = genreEntity;
    }

    public async Task UpdateAsync(Book entity, CancellationToken cancellationToken = default)
    {
        var existingBookEntity = await _dbContext.Books.FindAsync(entity.Id, cancellationToken);
        if (existingBookEntity != null)
        {
            _mapper.Map(entity, existingBookEntity);
            _dbContext.Books.Update(existingBookEntity);
        }
    }

    public async Task DeleteAsync(Book entity, CancellationToken cancellationToken = default)
    {
        var existingBookEntity = await _dbContext.Books.FindAsync(entity.Id, cancellationToken);
        if (existingBookEntity != null)
        {
            _dbContext.Books.Remove(existingBookEntity);
        }
    }

    public async Task<Book> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Books.Select(b => _mapper.Map<BookEntity, Book>(b))
            .AsQueryable()
            .FirstAsync(filter, cancellationToken);
    }
}