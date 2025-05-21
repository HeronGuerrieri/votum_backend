using Microsoft.EntityFrameworkCore;
using VotumServer.Data;
using VotumServer.Exceptions;
using VotumServer.Models;
using System.Threading.Tasks;

namespace VotumServer.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }
    }
}