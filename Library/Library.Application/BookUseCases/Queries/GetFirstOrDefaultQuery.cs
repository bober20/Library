using System.Linq.Expressions;

namespace Library.Application.BookUseCases.Queries;

public record GetFirstOrDefaultQuery(Expression<Func<Book, bool>> Filter) : IRequest<ResponseData<Book>>;