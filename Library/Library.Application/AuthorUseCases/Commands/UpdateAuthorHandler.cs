namespace Library.Application.AuthorUseCases.Commands;

public class UpdateAuthorHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateAuthorCommand, Author>
{
    public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.AuthorRepository.UpdateAsync(request.Author, cancellationToken);
        await unitOfWork.SaveAllAsync();

        return request.Author;
    }
}