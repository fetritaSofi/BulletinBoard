using BulletinBoard.Database.Models;

namespace BulletinBoard.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for user repository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        ///     Get users async
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetUsersAsync();

        /// <summary>
        ///     Get user by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        ///     Get user by email async
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        ///     Create user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> CreateUserAsync(User user);

        /// <summary>
        ///     Edit user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> EditUserAsync(User user);

        /// <summary>
        ///     Delete user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task DeleteUserAsync(User user);
    }
}
