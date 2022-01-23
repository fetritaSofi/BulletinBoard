using BulletinBoard.Controllers;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using BulletinBoard.Infrastructure.Models.Service.User;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     User controller test
    /// </summary>
    public class UserControllerTest
    {
        Mock<IUserService> userServiceMock;

        public UserControllerTest()
        {
            userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task GetUsers_ShouldReturn_Users()
        {
            //arrange
            List<UserDto> users = GetTestUsers();

            userServiceMock.Setup(r => r.GetUsersAsync()).Returns(Task.FromResult(users));

            UserController controller = new UserController(userServiceMock.Object);

            //act
            IActionResult? result = await controller.GetUsers();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetUserById_ShouldReturn_User()
        {
            //arrange
            var users = GetTestUsers();

            userServiceMock.Setup(r => r.GetUserByIdAsync(users[0].Id)).Returns(Task.FromResult(users[0]));

            UserController controller = new UserController(userServiceMock.Object);

            //act
            IActionResult? result = await controller.GetUser(users[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddUser_ShouldReturn_User()
        {
            //arrange
            UserDto user = new UserDto()
            {
                Id = 11,
                Name = "Joe",
                Email = "qwe@qwe.qwe",
                Password = "123"
            };

            userServiceMock.Setup(r => r.CreateUserAsync(user)).Returns(Task.FromResult(new CreateUserResponseModel() {User = user, Type = BulletinBoard.Infrastructure.Enums.UserResponseType.Success }));

            UserController controller = new UserController(userServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(user);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private List<UserDto> GetTestUsers()
        {
            List<UserDto> users = new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    Name = "John",
                    Email = "qqqqw@qwe.qwe",
                    Password = "321"
                },

                new UserDto
                {
                    Id = 2,
                    Name = "Jack",
                    Email = "erwin@qwe.qwe",
                    Password = "213"
                }
            };

            return users;
        }
    }
}
