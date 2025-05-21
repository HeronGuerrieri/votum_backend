namespace VotumServer.Repositories;

public interface IUserRepository
{
    Task UpdateLastLoginDateAsync(Guid userId);
}