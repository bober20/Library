namespace Library.Application.BookUseCases.Queries;

public class GetAllBooksHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllBooksQuery, IReadOnlyList<Book>>
{
    public async Task<IReadOnlyList<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.BookRepository.ListAllAsync(cancellationToken);
    }
}