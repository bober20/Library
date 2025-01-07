namespace Library.Application.BookUseCases.Queries;

public class GetFirstOrDefaultHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetFirstOrDefaultQuery, ResponseData<Book>>
{
    public Task<ResponseData<Book>> Handle(GetFirstOrDefaultQuery request, CancellationToken cancellationToken)
    {
        return unitOfWork.BookRepository.FirstOrDefaultAsync(request.Filter, cancellationToken);
    }
}