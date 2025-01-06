namespace Library.Application.BookUseCases.Commands;

public record AddBookCommand(Book Book) : IRequest<Book>;