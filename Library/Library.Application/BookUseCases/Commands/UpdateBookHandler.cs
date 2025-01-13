namespace Library.Application.BookUseCases.Commands;

public class UpdateBookHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateBookCommand, Book>
{
    public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.BookRepository.UpdateAsync(request.BookId, request.Book, cancellationToken);
        await unitOfWork.SaveAllAsync();
        
        return request.Book;
    }
}