using AutoMapper;
using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<Genre> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var genreEntity = await _dbContext.Genres.FirstOrDefaultAsync(g => g.GenreId == id, cancellationToken: cancellationToken);

        return _mapper.Map<GenreEntity, Genre>(genreEntity);
    }

    public async Task<IReadOnlyList<Genre>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        var genreEntities = await _dbContext.Genres.ToListAsync(cancellationToken: cancellationToken);

        IReadOnlyList<Genre> genres = genreEntities.Select(g => _mapper.Map<GenreEntity, Genre>(g)).ToList();

        return genres;
    }
    
    public async Task<Genre> AddAsync(Genre genre, CancellationToken cancellationToken = default)
    {
        var genreEntity = _mapper.Map<Genre, GenreEntity>(genre);
        await _dbContext.Genres.AddAsync(genreEntity, cancellationToken);
        
        return _mapper.Map<GenreEntity, Genre>(genreEntity);
    }
}