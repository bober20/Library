namespace Library.Application.BookUseCases.Queries;

public class GetBooksHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBooksQuery, IReadOnlyList<Book>>
{
    public async Task<IReadOnlyList<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.BookRepository.ListAsync(request.Filter, cancellationToken);
    }
}