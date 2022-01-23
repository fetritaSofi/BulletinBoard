using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.User;
using BulletinBoard.Infrastructure.Services;
using FluentAssertions;
using Mapster;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Timetable.Tests.Services
{
    /// <summary>
    ///     User service test
    /// </summary>
    public class UserServiceTest
    {
        Mock<IUserRepository> userRepositoryMock;

        public UserServiceTest()
        {
            userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task GetUsers_ShouldReturn_Users()
        {
            //arrange
            var users = GetTestUsers();

            userRepositoryMock.Setup(r => r.GetUsersAsync()).Returns(Task.FromResult(users.Adapt<List<User>>()));

            UserService service = new UserService(userRepositoryMock.Object);

            //act
            List<UserDto> result = await service.GetUsersAsync();

            //assert
            users.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetUserById_ShouldReturn_User()
        {
            //arrange
            var users = GetTestUsers();

            userRepositoryMock.Setup(r => r.GetUserByIdAsync(users[0].Id)).Returns(Task.FromResult(users[0].Adapt<User>()));

            UserService service = new UserService(userRepositoryMock.Object);

            //act
            UserDto result = await service.GetUserByIdAsync(users[0].Id);

            //assert
            users[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetUserByEmail_ShouldReturn_User()
        {
            //arrange
            var users = GetTestUsers();

            userRepositoryMock.Setup(r => r.GetUserByEmailAsync(users[0].Email)).Returns(Task.FromResult(users[0].Adapt<User>()));

            UserService service = new UserService(userRepositoryMock.Object);

            //act
            UserDto result = await service.GetUserByEmailAsync(users[0].Email);

            //assert
            users[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddUser_ShouldReturn_User()
        {
            //arrange
            UserDto user = new UserDto()
            {
                Id = 11,
                Name = "John",
                Email = "qwe@qwe.qwe",
                Password = "123"
            };

            userRepositoryMock.Setup(r => r.CreateUserAsync(user.Adapt<User>())).Returns(Task.FromResult(user.Adapt<User>()));

            UserService service = new UserService(userRepositoryMock.Object);

            //act
            CreateUserResponseModel result = await service.CreateUserAsync(user);

            //assert
            Assert.True(result.Type == BulletinBoard.Infrastructure.Enums.UserResponseType.Success);
        }

        private List<UserDto> GetTestUsers()
        {
            List<UserDto> users = new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    Name = "Jack",
                    Email = "ewq@qwe.qwe",
                    Password = "421"
                },
                new UserDto
                {
                    Id = 2,
                    Name = "Joi",
                    Email = "zxc@qwe.qwe",
                    Password = "321"
                }
            };

            return users;
        }
    }
}
