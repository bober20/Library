namespace Library.Application.BookUseCases.Commands;

public class DeleteBookHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookCommand, Book>
{
    public async Task<Book> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.BookRepository.DeleteAsync(request.Book, cancellationToken);
        await unitOfWork.SaveAllAsync();

        return request.Book;
    }
}