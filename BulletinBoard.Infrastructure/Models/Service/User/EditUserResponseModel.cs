using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;

namespace BulletinBoard.Infrastructure.Models.Service.User
{
    /// <summary>
    ///     Edit user response model
    /// </summary>
    public class EditUserResponseModel
    {
        public UserDto User { get; set; }
        public UserResponseType Type { get; set; }
    }
}
