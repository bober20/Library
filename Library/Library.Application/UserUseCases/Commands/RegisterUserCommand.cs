namespace Library.Application.UserUseCases.Commands;

public record RegisterUserCommand(string Email, string Password) : IRequest<bool>;