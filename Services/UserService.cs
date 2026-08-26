using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Notes_API.Database;
using Notes_API.Entities;
using Notes_API.Interfaces;

namespace Notes_API.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByCredentialsAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user is null)
                return null!;

            var hashedPassword = HashPassword(password);
            if (user.PasswordHash != hashedPassword)
                return null!;

            return user;
        }

        public async Task CreateUser(string name, string email, string password)
        {
            if (await _context.Users.AnyAsync(u => u.Email == email))
                throw new Exception("User with this email already exists");

            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = HashPassword(password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public string GetJwtToken(User user)
        {
            throw new NotImplementedException();
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}