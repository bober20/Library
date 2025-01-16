namespace Library.Application.Abstractions;

public interface IPasswordHasher
{
    public string GeneratePasswordHash(string password);

    public bool VerifyPasswordHash(string password, string passwordHash);
}