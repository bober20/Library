namespace Library.Application.AuthorUseCases.Queries;

public class GetAuthorByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAuthorByIdQuery, ResponseData<Author>>
{
    public async Task<ResponseData<Author>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.AuthorRepository.GetByIdAsync(request.Id, cancellationToken);

        return author;
    }
}