namespace Library.Application.AuthorUseCases.Queries;

public class GetAllAuthorsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllAuthorsQuery, IReadOnlyList<Author>>
{
    public Task<IReadOnlyList<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = unitOfWork.AuthorRepository.ListAllAsync(cancellationToken);

        return authors;
    }
}