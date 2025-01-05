using Library.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
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

        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        return services;
    }
}