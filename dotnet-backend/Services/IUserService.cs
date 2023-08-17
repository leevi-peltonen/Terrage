using TerrageApi.Models;
using TerrageApi.Models.DTO;

namespace TerrageApi.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Returns user that has been created to database
        /// </summary>
        /// <param name="user">User DTO for creating user</param>
        /// <returns></returns>
        public Task<User> CreateUserAsync(User user);

        /// <summary>
        /// Gets user from database and returns it
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<User> ReadUserAsync(int id);
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> UpdateUserAsync(User user);
        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        public Task DeleteUserAsync(int id);
        /// <summary>
        /// Check if user exists with given name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> UserExists(string username);
        /// <summary>
        /// Find user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Task<User> GetUserByUsernameAsync(string username);
    }
}

