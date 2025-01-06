namespace Library.Application.AuthorUseCases.Commands;

public class AddAuthorHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddAuthorCommand, Author>
{
    public async Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.AuthorRepository.AddAsync(request.Author, cancellationToken);
        await unitOfWork.SaveAllAsync();
        
        return request.Author;
    }
}