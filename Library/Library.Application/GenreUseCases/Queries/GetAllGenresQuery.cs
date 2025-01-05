using MediatR;

namespace Library.Application.GenreUseCases.Queries;

public record GetAllGenresQuery : IRequest<IReadOnlyList<Genre>>;