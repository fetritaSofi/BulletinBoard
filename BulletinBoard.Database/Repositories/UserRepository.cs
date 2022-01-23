using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Database.Repositories
{
    /// <summary>
    ///     User repository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get users async
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUsersAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        /// <summary>
        ///     Get user by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        ///     Get user by email async
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        ///     Create user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> CreateUserAsync(User user)
        {
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();

            return user;
        }

        /// <summary>
        ///     Edit user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> EditUserAsync(User user)
        {
            _databaseContext.Users.Update(user);
            await _databaseContext.SaveChangesAsync();

            return user;
        }

        /// <summary>
        ///     Delete user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DeleteUserAsync(User user)
        {
            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
