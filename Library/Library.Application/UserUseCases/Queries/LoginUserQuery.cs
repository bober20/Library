namespace Library.Application.UserUseCases.Queries;

public record LoginUserQuery(string Email, string Password) : IRequest<string>;