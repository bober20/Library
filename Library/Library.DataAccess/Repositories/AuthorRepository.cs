namespace Library.DataAccess.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private LibraryDbContext _dbContext;
    private IMapper _mapper;
    
    public AuthorRepository(LibraryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<ResponseData<Author>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var authorEntity = await _dbContext.Authors.FindAsync(id, cancellationToken);
        var author = _mapper.Map<AuthorEntity, Author>(authorEntity);
        
        return ResponseData<Author>.Success(author);
    }

    public async Task<ResponseData<IReadOnlyList<Author>>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        var authorsEntities = await _dbContext.Authors.AsNoTracking().ToListAsync(cancellationToken);
        var authors = authorsEntities.Select(a => _mapper.Map<AuthorEntity, Author>(a)).ToList();
        return ResponseData<IReadOnlyList<Author>>.Success(authors);
    }

    public async Task AddAsync(Author entity, CancellationToken cancellationToken = default)
    {
        var authorEntity = _mapper.Map<Author, AuthorEntity>(entity);
        await _dbContext.Authors.AddAsync(authorEntity, cancellationToken);
    }

    public async Task UpdateAsync(Author entity, CancellationToken cancellationToken = default)
    {
        var existingAuthorEntity = await _dbContext.Authors.FindAsync(entity.Id, cancellationToken);
        if (existingAuthorEntity != null)
        {
            _mapper.Map(entity, existingAuthorEntity);
            _dbContext.Authors.Update(existingAuthorEntity);
        }
    }

    public async Task DeleteAsync(Author entity, CancellationToken cancellationToken = default)
    {
        var existingAuthorEntity = await _dbContext.Authors.FindAsync(entity.Id, cancellationToken);
        if (existingAuthorEntity != null)
        {
            _dbContext.Authors.Remove(existingAuthorEntity);
        }
    }
    
    public async Task<ResponseData<IReadOnlyList<Book>>> GetAllAuthorBooks(Guid id, CancellationToken cancellationToken = default)
    {
        var authorEntity = await _dbContext.Authors.FindAsync(id);
        await _dbContext.Entry(authorEntity).Collection(a => a.Books).LoadAsync(cancellationToken);
        var books = authorEntity.Books.Select(b => _mapper.Map<BookEntity, Book>(b)).ToList();

        return ResponseData<IReadOnlyList<Book>>.Success(books);
    }
    
    public async Task<ResponseData<ListModel<Book>>> GetAllAuthorBooks(Guid id, int pageNo, int pageSize, CancellationToken cancellationToken = default)
    {
        var authorEntity = await _dbContext.Authors.FindAsync(id);
        await _dbContext.Entry(authorEntity).Collection(a => a.Books).LoadAsync(cancellationToken);
        var books = authorEntity.Books.Select(b => _mapper.Map<BookEntity, Book>(b)).ToList();
        
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
}