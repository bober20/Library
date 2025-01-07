namespace Library.Application.AuthorUseCases.Queries;

public record GetAllAuthorBooksQuery(Guid Id, int PageNo, int PageSize) : IRequest<ResponseData<ListModel<Book>>>;