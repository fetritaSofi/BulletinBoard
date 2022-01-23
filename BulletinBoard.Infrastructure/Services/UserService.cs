using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.User;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Mapster;

namespace BulletinBoard.Infrastructure.Services
{
    /// <summary>
    ///     User service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        ///     Get users async
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserDto>> GetUsersAsync()
        {
            List<User> Users = await _userRepository.GetUsersAsync();
            return Users.Adapt<List<UserDto>>();
        }

        /// <summary>
        ///     Get user by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            User Users = await _userRepository.GetUserByIdAsync(id);
            return Users.Adapt<UserDto>();
        }

        /// <summary>
        ///     Get user by email async
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            User Users = await _userRepository.GetUserByEmailAsync(email);
            return Users.Adapt<UserDto>();
        }

        /// <summary>
        ///     Create user async
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task<CreateUserResponseModel> CreateUserAsync(UserDto UserDto)
        {
            User User = UserDto.Adapt<User>();
            User UserCreated = await _userRepository.CreateUserAsync(User);

            return new CreateUserResponseModel()
            {
                User = UserCreated.Adapt<UserDto>(),
                Type = UserResponseType.Success
            };
        }

        /// <summary>
        ///     Edit user async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task<EditUserResponseModel> EditUserAsync(int id, UserDto UserDto)
        {
            User User = await _userRepository.GetUserByIdAsync(id);

            if (User == null)
            {
                return new EditUserResponseModel()
                {
                    Type = UserResponseType.UserNotFound
                };
            }

            UserDto.Id = User.Id;

            User UserModel = UserDto.Adapt<User>();
            User UserEdited = await _userRepository.EditUserAsync(UserModel);

            return new EditUserResponseModel()
            {
                User = UserEdited.Adapt<UserDto>(),
                Type = UserResponseType.Success
            };
        }

        /// <summary>
        ///     Delete user async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResponseType> DeleteUserAsync(int id)
        {
            User User = await _userRepository.GetUserByIdAsync(id);

            if (User == null)
            {
                return UserResponseType.UserNotFound;
            }

            await _userRepository.DeleteUserAsync(User);

            return UserResponseType.Success;
        }
    }
}

