namespace Library.Application.GenreUseCases.Queries;

public class GetGenreByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetGenreByIdQuery, ResponseData<Genre>>
{
    public async Task<ResponseData<Genre>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.GenreRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}