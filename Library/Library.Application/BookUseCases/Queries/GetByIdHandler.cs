namespace Library.Application.BookUseCases.Queries;

public class GetByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetByIdQuery, Book>
{
    public Task<Book> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return unitOfWork.BookRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}