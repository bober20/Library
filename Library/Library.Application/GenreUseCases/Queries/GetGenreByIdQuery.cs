namespace Library.Application.GenreUseCases.Queries;

public record GetGenreByIdQuery(Guid Id) : IRequest<ResponseData<Genre>>;