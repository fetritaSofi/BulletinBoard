using BulletinBoard.Database;
using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Timetable.Tests.Repositories
{
    /// <summary>
    ///     User repository test
    /// </summary>
    public class UserRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public UserRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetUsers_ShouldReturn_Users()
        {
            //arange
            ClearDatabase(context);

            var usersNew = AddDb(context);

            var userRepository = new UserRepository(context);

            //act
            var result = await userRepository.GetUsersAsync();

            //assert
            usersNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetUserById_ShouldReturn_User()
        {
            //arrange
            ClearDatabase(context);

            var usersNew = AddDb(context);

            var userRepository = new UserRepository(context);

            //act
            var result = await userRepository.GetUserByIdAsync(usersNew[0].Id);

            //assert
            usersNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetUserByEmail_ShouldReturn_User()
        {
            //arrange
            ClearDatabase(context);

            var usersNew = AddDb(context);

            var userRepository = new UserRepository(context);

            //act
            var result = await userRepository.GetUserByEmailAsync(usersNew[0].Email);

            //assert
            usersNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddUser_ShouldReturn_User()
        {
            //arrange
            var user = new User
            {
                Id = 11,
                Name = "Josh",
                Email = "joshua@reil.mo",
                Password = "123"
            };

            var userRepository = new UserRepository(context);

            //act
            var result = await userRepository.CreateUserAsync(user);

            //assert
            user.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditUser_ShouldReturn_User()
        {
            //arrange
            ClearDatabase(context);

            var usersNew = AddDb(context);
            var userRepository = new UserRepository(context);

            //act
            var result = await userRepository.EditUserAsync(usersNew[0]);

            //assert
            usersNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteUser_ShouldReturn_User()
        {
            //arrange
            ClearDatabase(context);

            var usersNew = AddDb(context);
            var userRepository = new UserRepository(context);

            //act
            await userRepository.DeleteUserAsync(usersNew[1]);

            //assert
            Assert.True(context.Users.FirstOrDefault(t => t.Id == usersNew[1].Id) == null);
        }

        private User[] AddDb(DatabaseContext database)
        {
            var usersNew = new[] {

                new User
                {
                    Id = 1,
                    Name = "John",
                    Email = "jhnDo@reil.mo",
                    Password = "321"
                },

                new User
                {
                    Id = 2,
                    Name = "Sally",
                    Email = "sallyGrom@reil.mo",
                    Password = "221"
                }
            };

            database.Users.AddRange(usersNew);
            database.SaveChanges();

            return usersNew;
        }

        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Users)
                context.Users.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
