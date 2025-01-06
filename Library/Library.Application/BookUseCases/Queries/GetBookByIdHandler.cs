namespace Library.Application.BookUseCases.Queries;

public class GetBookByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBookByIdQuery, Book>
{
    public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return unitOfWork.BookRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}