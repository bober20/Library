namespace Library.Application.AuthorUseCases.Queries;

public class GetAllAuthorBooksHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllAuthorBooksQuery, ResponseData<ListModel<Book>>>
{
    public async Task<ResponseData<ListModel<Book>>> Handle(GetAllAuthorBooksQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.AuthorRepository.GetAllAuthorBooks(request.Id, request.PageNo, request.PageSize, cancellationToken);
    }
}