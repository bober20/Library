namespace Library.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private IMapper _mapper;
    private LibraryDbContext _dbContext;

    public UserRepository(IMapper mapper, LibraryDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    
    public async Task Add(User user)
    {
        var userEntity = _mapper.Map<User, UserEntity>(user);
        await _dbContext.AddAsync(userEntity);
    }

    public async Task<User?> GetByEmail(string email)
    {
        var requiredUser = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);

        return _mapper.Map<UserEntity, User>(requiredUser);
    }
}