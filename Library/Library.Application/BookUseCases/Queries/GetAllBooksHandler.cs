namespace Library.Application.BookUseCases.Queries;

public class GetAllBooksHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllBooksQuery, ResponseData<ListModel<Book>>>
{
    public async Task<ResponseData<ListModel<Book>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.BookRepository.ListAllAsync(request.PageNo, request.PageSize, cancellationToken);
    }
}