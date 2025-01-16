namespace Library.Application.UserUseCases.Commands;

public class RegisterUserHandler(IUnitOfWork unitOfWork) : IRequestHandler<RegisterUserCommand, bool>
{
    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = unitOfWork.PasswordHasher.GeneratePasswordHash(request.Password);
        var user = new User(request.Email, hashedPassword);

        await unitOfWork.UserRepository.Add(user);
        await unitOfWork.SaveAllAsync();
        
        return true;
    }
}