namespace Library.Application.BookUseCases.Commands;

public class DeleteBookHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookCommand, bool>
{
    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var isDeleted = await unitOfWork.BookRepository.DeleteAsync(request.Id, cancellationToken);
        await unitOfWork.SaveAllAsync();

        return isDeleted;
    }
}