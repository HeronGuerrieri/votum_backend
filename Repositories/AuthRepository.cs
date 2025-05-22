using Microsoft.EntityFrameworkCore;
using VotumServer.Data;
using VotumServer.Exceptions;
using VotumServer.Models;
using System.Threading.Tasks;

namespace VotumServer.Repositories
{
    public class AuthRepository(ApplicationDbContext context) : IAuthRepository
    {
        public async Task<User> RegisterAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }
    }
}