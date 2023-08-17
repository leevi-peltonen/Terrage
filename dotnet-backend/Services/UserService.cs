using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using TerraVillageAPI.Models;
using TerraVillageAPI.Models.DTO;

namespace TerraVillageAPI.Services
{
    public class UserService : IUserService
    {

        private readonly TerraVillageDBContext _context;

        public UserService(TerraVillageDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> ReadUserAsync(int id)
        {
            User user = await _context.Users
                .Include(u => u.Achievements)
                .Include(u => u.Clan)
                .Include(u => u.Friends)
                .Include(u => u.Settings)
                .Include(u => u.Village)
                .FirstAsync(u => u.ID == id);
            return user;
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
