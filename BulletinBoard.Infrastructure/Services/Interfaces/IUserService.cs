using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.User;

namespace BulletinBoard.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for user repository
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Get users async
        /// </summary>
        /// <returns></returns>
        Task<List<UserDto>> GetUsersAsync();

        /// <summary>
        ///     Get user by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserDto> GetUserByIdAsync(int id);

        /// <summary>
        ///     Get user by email async
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserDto> GetUserByEmailAsync(string email);

        /// <summary>
        ///     Create user async
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<CreateUserResponseModel> CreateUserAsync(UserDto UserDto);

        /// <summary>
        ///     Edit user async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<EditUserResponseModel> EditUserAsync(int id, UserDto UserDto);

        /// <summary>
        ///     Delete user async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResponseType> DeleteUserAsync(int id);
    }
}
