namespace Library.Application.AuthorUseCases.Queries;

public record GetAllAuthorsQuery : IRequest<ResponseData<IReadOnlyList<Author>>>;