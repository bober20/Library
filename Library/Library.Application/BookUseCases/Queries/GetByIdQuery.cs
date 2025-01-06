namespace Library.Application.BookUseCases.Queries;

public record GetByIdQuery(Guid Id) : IRequest<Book>;