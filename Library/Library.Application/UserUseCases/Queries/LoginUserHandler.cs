namespace Library.Application.UserUseCases.Queries;

public class LoginUserHandler(IUnitOfWork unitOfWork) : IRequestHandler<LoginUserQuery, string>
{
    public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByEmail(request.Email);
        var isPasswordCorrect = unitOfWork.PasswordHasher.VerifyPasswordHash(request.Password, user?.PasswordHash);
        if (!isPasswordCorrect)
        {
            return string.Empty;
        }

        var token = unitOfWork.JwtProvider.GenerateToken(user);

        return token;
    }
}