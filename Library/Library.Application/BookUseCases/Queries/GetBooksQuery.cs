using System.Linq.Expressions;

namespace Library.Application.BookUseCases.Queries;

public record GetBooksQuery(int PageNo, int PageSize, Expression<Func<Book, bool>> Filter) : IRequest<ResponseData<ListModel<Book>>>;