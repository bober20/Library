using Library.Application.Abstractions;

namespace Library.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string GeneratePasswordHash(string password)
    {
        var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        
        return string.Empty;
    }

    public bool VerifyPasswordHash(string password, string passwordHash)
    {
        var anotherPasswordHash = GeneratePasswordHash(password);
        return passwordHash == anotherPasswordHash;
    }
}