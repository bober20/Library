using AutoMapper;
using Library.Core.Models;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Mappers;

public class Mapper
{
    private readonly IMapper _mapper;

    static Mapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<GenreEntity, Genre>();
            cfg.CreateMap<AuthorEntity, Author>();
            cfg.CreateMap<BookEntity, Book>();
        });
    }
    
}