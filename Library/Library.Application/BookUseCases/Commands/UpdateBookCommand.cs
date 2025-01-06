namespace Library.Application.BookUseCases.Commands;

public record UpdateBookCommand(Book Book) : IRequest<Book>;