namespace Library.Application.BookUseCases.Queries;

public record GetAllBooksQuery : IRequest<IReadOnlyList<Book>>;