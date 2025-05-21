using System.Security.Cryptography;
using VotumServer.Exceptions;
using VotumServer.Models;
using VotumServer.Repositories;

namespace VotumServer.Services
{
    public class AuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> RegisterUserAsync(User user, string password)
        {
            user.PasswordHash = HashPassword(password);
            user.DateCreated = DateTime.UtcNow;
            user.IsActive = true;

            return await _authRepository.RegisterAsync(user);
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _authRepository.GetUserByUsernameAsync(username);

            var isPasswordValid = VerifyPassword(password, user.PasswordHash);
            if (!isPasswordValid) throw new IncorrectCredentialException();

            return user;
        }

        private string HashPassword(string password)
        {
            const int saltSize = 16;
            const int hashSize = 20;
            const int iterations = 10000;

            var salt = new byte[saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(hashSize);

            var hashBytes = new byte[saltSize + hashSize];
            Array.Copy(salt, 0, hashBytes, 0, saltSize);
            Array.Copy(hash, 0, hashBytes, saltSize, hashSize);

            return Convert.ToBase64String(hashBytes);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            const int saltSize = 16;
            const int hashSize = 20;
            const int iterations = 10000;

            var hashBytes = Convert.FromBase64String(storedHash);

            var salt = new byte[saltSize];
            Array.Copy(hashBytes, 0, salt, 0, saltSize);

            var storedSubHash = new byte[hashSize];
            Array.Copy(hashBytes, saltSize, storedSubHash, 0, hashSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var computedHash = pbkdf2.GetBytes(hashSize);

            for (int i = 0; i < hashSize; i++)
            {
                if (storedSubHash[i] != computedHash[i]) return false;
            }

            return true;
        }
    }
}
