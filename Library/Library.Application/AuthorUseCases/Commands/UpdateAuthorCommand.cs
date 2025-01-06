namespace Library.Application.AuthorUseCases.Commands;

public record UpdateAuthorCommand(Author Author) : IRequest<Author>;