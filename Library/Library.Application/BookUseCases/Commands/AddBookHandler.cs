namespace Library.Application.BookUseCases.Commands;

public class AddBookHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddBookCommand, Book>
{
    public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.BookRepository.AddAsync(request.Book, cancellationToken);
        await unitOfWork.SaveAllAsync();
        
        return request.Book;
    }
}