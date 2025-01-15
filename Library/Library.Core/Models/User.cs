namespace Library.Core.Models;

public class User
{
    public User(Guid id, string email, string passwordHash)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
    }
    
    public Guid Id { get; }
    public string Email { get; }
    public string PasswordHash { get; }
}