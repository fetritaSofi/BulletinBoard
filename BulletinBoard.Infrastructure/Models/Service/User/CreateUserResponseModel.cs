using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;

namespace BulletinBoard.Infrastructure.Models.Service.User
{
    /// <summary>
    ///     Create user response model
    /// </summary>
    public class CreateUserResponseModel
    {
        public UserDto User { get; set; }
        public UserResponseType Type { get; set; }
    }
}
