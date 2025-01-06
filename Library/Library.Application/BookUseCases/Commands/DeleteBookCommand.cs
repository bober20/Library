namespace Library.Application.BookUseCases.Commands;

public record DeleteBookCommand(Book Book) : IRequest<Book>;