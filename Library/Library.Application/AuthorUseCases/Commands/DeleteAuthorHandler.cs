namespace Library.Application.AuthorUseCases.Commands;

public class DeleteAuthorHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteAuthorCommand, Author>
{
    public async Task<Author> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.AuthorRepository.DeleteAsync(request.Author, cancellationToken);
        await unitOfWork.SaveAllAsync();

        return request.Author;
    }
}