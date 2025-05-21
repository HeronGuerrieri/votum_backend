using VotumServer.Models;

namespace VotumServer.Repositories;

public interface IAuthRepository
{
    Task<User> RegisterAsync(User user);
    Task<User> GetUserByUsernameAsync(string username);

}