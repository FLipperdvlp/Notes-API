using Notes_API.Entities;

namespace Notes_API.Interfaces;

public interface IAuthService
{
    Task<User?> RegisterAsync(string name, string email, string password);
    Task<string?> LoginAsync(string email, string password);
}