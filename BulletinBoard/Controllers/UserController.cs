using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.User;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            List<UserDto> users = await _userService.GetUsersAsync();

            return Ok(users);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            UserDto user = await _userService.GetUserByIdAsync(id);

            return Ok(user);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<IActionResult> GetUser(string email)
        {
            UserDto user = await _userService.GetUserByEmailAsync(email);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto user)
        {
            CreateUserResponseModel createUserResponse = await _userService.CreateUserAsync(user);

            if (createUserResponse.Type == UserResponseType.Success)
            {
                return Ok(createUserResponse);
            }

            return BadRequest(createUserResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UserDto user)
        {
            EditUserResponseModel editUserResponse = await _userService.EditUserAsync(id, user);

            if (editUserResponse.Type == UserResponseType.Success)
            {
                return Ok(editUserResponse);
            }

            return BadRequest(editUserResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            UserResponseType userResponse = await _userService.DeleteUserAsync(id);

            if (userResponse == UserResponseType.Success)
            {
                return Ok(userResponse);
            }

            return BadRequest(userResponse);
        }
    }
}
