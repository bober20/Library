namespace Library.Application.GenreUseCases.Queries;

public class GetAllGenresHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllGenresQuery, IReadOnlyList<Genre>>
{
    public async Task<IReadOnlyList<Genre>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.GenreRepository.ListAllAsync(cancellationToken);
    }
}