namespace Library.Application.AuthorUseCases.Commands;

public record DeleteAuthorCommand(Author Author) : IRequest<Author>;