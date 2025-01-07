namespace Library.Application.GenreUseCases.Queries;

public record GetAllGenresQuery : IRequest<ResponseData<IReadOnlyList<Genre>>>;