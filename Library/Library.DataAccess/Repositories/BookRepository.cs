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
    
    public async Task<ResponseData<Book>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bookEntity = await _dbContext.Books.FindAsync(id, cancellationToken);
        var book = _mapper.Map<BookEntity, Book>(bookEntity);
        return ResponseData<Book>.Success(book);
    }

    public async Task<ResponseData<IReadOnlyList<Book>>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        var bookEntities = await _dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
        var books = bookEntities.Select(b => _mapper.Map<BookEntity, Book>(b)).ToList();

        return ResponseData<IReadOnlyList<Book>>.Success(books);
    }
    
    public async Task<ResponseData<IReadOnlyList<Book>>> ListAsync(Expression<Func<Book, bool>> filter, 
        CancellationToken cancellationToken = default)
    {
        var bookEntities = await _dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
        var books = await bookEntities.Select(b => _mapper.Map<BookEntity, Book>(b))
            .AsQueryable()
            .Where(filter)
            .ToListAsync(cancellationToken);

        return ResponseData<IReadOnlyList<Book>>.Success(books);
    }

    public async Task<ResponseData<ListModel<Book>>> ListAllAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default)
    {
        var bookEntities = await _dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
        var books = bookEntities.Select(b => _mapper.Map<BookEntity, Book>(b)).ToList();

        var booksListModel = new ListModel<Book>();
        var count = books.Count;
        var totalPages = (int)Math.Ceiling((double)(count / pageSize));

        if (count == 0)
        {
            return ResponseData<ListModel<Book>>.Success(booksListModel); 
        }
        
        booksListModel.Items = books.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
        booksListModel.CurrentPage = pageNo;
        booksListModel.TotalPages = totalPages;

        return ResponseData<ListModel<Book>>.Success(booksListModel);
    }

    public async Task<ResponseData<ListModel<Book>>> ListAsync(int pageNo, int pageSize, 
        Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default)
    {
        var bookEntities = await _dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
        var books = await bookEntities.Select(b => _mapper.Map<BookEntity, Book>(b))
            .AsQueryable()
            .Where(filter)
            .ToListAsync(cancellationToken);
        
        var booksListModel = new ListModel<Book>();
        var count = books.Count;
        var totalPages = (int)Math.Ceiling((double)(count / pageSize));

        if (count == 0)
        {
            return ResponseData<ListModel<Book>>.Success(booksListModel);
        }
        
        booksListModel.Items = books.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
        booksListModel.CurrentPage = pageNo;
        booksListModel.TotalPages = totalPages;

        return ResponseData<ListModel<Book>>.Success(booksListModel);
    }

    public async Task AddAsync(Book entity, CancellationToken cancellationToken = default)
    {
        var bookEntity = _mapper.Map<Book, BookEntity>(entity);
        bookEntity.Author = await _dbContext.Authors.FindAsync(bookEntity.AuthorId);
        bookEntity.Genre = await _dbContext.Genres.FindAsync(bookEntity.GenreId);
        
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
    
    public async Task<ResponseData<Book>> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default)
    {
        var book = await _dbContext.Books.Select(b => _mapper.Map<BookEntity, Book>(b))
            .AsQueryable()
            .FirstAsync(filter, cancellationToken);

        return ResponseData<Book>.Success(book);
    }
}