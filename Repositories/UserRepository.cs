using VotumServer.Data;

namespace VotumServer.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task UpdateLastLoginDateAsync(Guid userId)
    {
        var user = await context.Users.FindAsync(userId);
        if (user != null)
        {
            user.LastLoginDate = DateTime.UtcNow;
            await context.SaveChangesAsync();
        }
    }
}