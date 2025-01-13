namespace Library.Application.BookUseCases.Commands;

public record DeleteBookCommand(Guid Id) : IRequest<bool>;