namespace Library.Application.BookUseCases.Queries;

public class GetBooksHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBooksQuery, ResponseData<ListModel<Book>>>
{
    public async Task<ResponseData<ListModel<Book>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.BookRepository.ListAsync(request.PageNo, request.PageSize, request.Filter, cancellationToken);
    }
}