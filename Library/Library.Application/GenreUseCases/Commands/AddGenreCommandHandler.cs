namespace Library.Application.GenreUseCases.Commands;

public class AddGenreCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddGenreCommand, Genre>
{
    public async Task<Genre> Handle(AddGenreCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.GenreRepository.AddAsync(request.Genre, cancellationToken);
        await unitOfWork.SaveAllAsync();

        return request.Genre;
    }
}