namespace Library.Application.GenreUseCases.Queries;

public class GetAllGenresHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllGenresQuery, ResponseData<IReadOnlyList<Genre>>>
{
    public async Task<ResponseData<IReadOnlyList<Genre>>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.GenreRepository.ListAllAsync(cancellationToken);
    }
}