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
        });

        IMapper mapper = config.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }

    private static Author MapAuthor(AuthorEntity src, ResolutionContext resolutionContext)
    {
        return new Author(src.AuthorId, src.FirstName, src.LastName, src.BirthDate, src.Country,
            src.Books?.Select(b => MapBook(b, resolutionContext)).ToList());
    }

    private static Book MapBook(BookEntity src, ResolutionContext resolutionContext)
    {
        return new Book(src.BookId, src.ISBN, src.Title, src.ImageUrl,
            new Genre(src.Genre.GenreId, src.Genre.Name), src.Description,
            new Author(src.Author.AuthorId, src.Author.FirstName, src.Author.LastName,
                src.Author.BirthDate, src.Author.Country, null),
            src.BorrowDate, src.DueDate);
    }
}