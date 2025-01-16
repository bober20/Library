namespace Library.Application.Abstractions;

public interface IJwtProvider
{
    public string GenerateToken(User user);
}