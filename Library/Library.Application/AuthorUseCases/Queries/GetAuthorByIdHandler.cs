namespace Library.Application.AuthorUseCases.Queries;

public class GetAuthorByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAuthorByIdQuery, Author>
{
    public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.AuthorRepository.GetByIdAsync(request.Id, cancellationToken);

        return author;
    }
}