namespace Library.Application.AuthorUseCases.Queries;

public class GetAllAuthorBooksHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllAuthorBooksQuery, IReadOnlyCollection<Book>>
{
    public async Task<IReadOnlyCollection<Book>> Handle(GetAllAuthorBooksQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.AuthorRepository.GetAllAuthorBooks(request.Id, cancellationToken);
    }
}