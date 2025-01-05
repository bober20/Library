using MediatR;

namespace Library.Application.GenreUseCases.Commands;

public record AddGenreCommand(Genre Genre) : IRequest<Genre>;