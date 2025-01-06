namespace Library.Application.BookUseCases.Queries;

public record GetBookByIdQuery(Guid Id) : IRequest<Book>;