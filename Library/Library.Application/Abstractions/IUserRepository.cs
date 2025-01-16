namespace Library.Application.Abstractions;

public interface IUserRepository
{
    public Task Add(User user);
    public Task<User?> GetByEmail(string email);
}