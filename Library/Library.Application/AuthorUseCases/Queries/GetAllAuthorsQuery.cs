namespace Library.Application.AuthorUseCases.Queries;

public record GetAllAuthorsQuery : IRequest<IReadOnlyList<Author>>;