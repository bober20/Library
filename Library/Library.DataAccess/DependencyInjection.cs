using AutoMapper;
using Library.Core.Models;
using Library.DataAccess.Entities;
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

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<GenreEntity, Genre>()
                .ConstructUsing(src => new Genre(src.GenreId, src.Name))
                .ReverseMap();
            cfg.CreateMap<AuthorEntity, Author>().ReverseMap();
            cfg.CreateMap<BookEntity, Book>().ReverseMap();
        });

        IMapper mapper = config.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }
}