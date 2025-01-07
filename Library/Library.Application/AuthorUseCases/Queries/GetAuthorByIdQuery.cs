namespace Library.Application.AuthorUseCases.Queries;

public record GetAuthorByIdQuery(Guid Id) : IRequest<ResponseData<Author>>;