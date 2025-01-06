namespace Library.Application.GenreUseCases.Queries;

public class GetGenreByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetGenreByIdQuery, Genre>
{
    public async Task<Genre> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.GenreRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}