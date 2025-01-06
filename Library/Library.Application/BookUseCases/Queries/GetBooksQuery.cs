using System.Linq.Expressions;

namespace Library.Application.BookUseCases.Queries;

public record GetBooksQuery(Expression<Func<Book, bool>> Filter) : IRequest<IReadOnlyList<Book>>;