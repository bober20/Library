namespace Library.Application.BookUseCases.Commands;

public record UpdateBookCommand(Guid BookId, Book Book) : IRequest<Book>;