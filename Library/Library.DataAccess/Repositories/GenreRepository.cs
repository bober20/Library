namespace Library.DataAccess.Repositories;

public class GenreRepository : IGenreRepository
{
    private LibraryDbContext _dbContext;
    private IMapper _mapper;
    
    public GenreRepository(LibraryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<ResponseData<Genre>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var genreEntity = await _dbContext.Genres.FirstOrDefaultAsync(g => g.GenreId == id, cancellationToken: cancellationToken);
        var genre = _mapper.Map<GenreEntity, Genre>(genreEntity);

        return ResponseData<Genre>.Success(genre);
    }

    public async Task<ResponseData<IReadOnlyList<Genre>>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        var genreEntities = await _dbContext.Genres.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
        IReadOnlyList<Genre> genres = genreEntities.Select(g => _mapper.Map<GenreEntity, Genre>(g)).ToList();

        return ResponseData<IReadOnlyList<Genre>>.Success(genres);
    }
    
    public async Task AddAsync(Genre genre, CancellationToken cancellationToken = default)
    {
        var genreEntity = _mapper.Map<Genre, GenreEntity>(genre);
        await _dbContext.Genres.AddAsync(genreEntity, cancellationToken);
    }
}