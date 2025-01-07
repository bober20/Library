namespace Library.Application.AuthorUseCases.Queries;

public record GetAllAuthorBooksQuery(Guid Id) : IRequest<IReadOnlyCollection<Book>>;