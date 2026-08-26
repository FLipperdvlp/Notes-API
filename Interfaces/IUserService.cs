using Notes_API.Entities;

namespace Notes_API.Interfaces;

public interface IUserService
{
    Task<User?> GetUserByCredentialsAsync(string email, string password);

    string GetJwtToken(User user);

    Task CreateUser(string name, string email, string password);
}