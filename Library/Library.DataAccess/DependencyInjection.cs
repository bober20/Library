using Library.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Library.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
    {
        services.AddDbContext<LibraryDbContext>(options);
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IGenreRepository, GenreRepository>();
        services.AddTransient<IAuthorRepository, AuthorRepository>();
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<GenreEntity, Genre>()
                .ConstructUsing(src => new Genre(src.GenreId, src.Name))
                .ReverseMap();
            cfg.CreateMap<AuthorEntity, Author>()
                .ConstructUsing(MapAuthor)
                .ReverseMap();
            cfg.CreateMap<BookEntity, Book>()
                .ConstructUsing(MapBook)
                .ReverseMap();
            cfg.CreateMap<UserEntity, User>()
                .ConstructUsing(src => new User(src.UserId, src.Email, src.PasswordHash))
                .ReverseMap();
        });

        IMapper mapper = config.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }

    private static Author MapAuthor(AuthorEntity src, ResolutionContext resolutionContext)
    {
        return new Author(src.AuthorId, src.FirstName, src.LastName, src.BirthDate, src.Country);
    }

    private static Book MapBook(BookEntity src, ResolutionContext resolutionContext)
    {
        return new Book(src.BookId, src.ISBN, src.Title, src.ImageUrl,
            src.GenreId, src.Description, src.AuthorId, src.BorrowDate, src.DueDate, src.UserId ?? Guid.Empty);
    }
}