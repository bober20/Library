namespace Library.Application.BookUseCases.Queries;

public record GetAllBooksQuery(int PageNo, int PageSize) : IRequest<ResponseData<ListModel<Book>>>;