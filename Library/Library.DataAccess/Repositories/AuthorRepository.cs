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
    
    public async Task<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var authorEntity = await _dbContext.Authors.FindAsync(id, cancellationToken);
        
        return _mapper.Map<AuthorEntity, Author>(authorEntity);
    }

    public async Task<IReadOnlyList<Author>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        var authorsEntities = await _dbContext.Authors.ToListAsync(cancellationToken);
        return authorsEntities.Select(a => _mapper.Map<AuthorEntity, Author>(a)).ToList();
    }

    public async Task AddAsync(Author entity, CancellationToken cancellationToken = default)
    {
        var authorEntity = _mapper.Map<Author, AuthorEntity>(entity);
        await _dbContext.Authors.AddAsync(authorEntity, cancellationToken);
    }

    public async Task UpdateAsync(Author entity, CancellationToken cancellationToken = default)
    {
        var authorEntity = _mapper.Map<Author, AuthorEntity>(entity);
        
        _dbContext.Authors.Update(authorEntity);
    }

    public async Task DeleteAsync(Author entity, CancellationToken cancellationToken = default)
    {
        var authorEntity = _mapper.Map<Author, AuthorEntity>(entity);
        
        _dbContext.Authors.Remove(authorEntity);
    }
}