namespace Library.Application.AuthorUseCases.Commands;

public record AddAuthorCommand(Author Author) : IRequest<Author>;