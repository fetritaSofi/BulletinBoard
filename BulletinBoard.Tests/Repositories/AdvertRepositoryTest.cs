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
    ///     Advert repository test
    /// </summary>
    public class AdvertRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public AdvertRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetAdverts_ShouldReturn_Adverts()
        {
            //arange
            ClearDatabase(context);

            var advertsNew = AddDb(context);

            var advertRepository = new AdvertRepository(context);

            //act
            var result = await advertRepository.GetAdvertsAsync();

            //assert
            advertsNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAdvertById_ShouldReturn_Advert()
        {
            //arrange
            ClearDatabase(context);

            var advertsNew = AddDb(context);

            var advertRepository = new AdvertRepository(context);

            //act
            var result = await advertRepository.GetAdvertByIdAsync(advertsNew[0].Id);

            //assert
            advertsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAdvertByName_ShouldReturn_Advert()
        {
            //arrange
            ClearDatabase(context);

            var advertsNew = AddDb(context);

            var advertRepository = new AdvertRepository(context);

            //act
            var result = await advertRepository.GetAdvertByNameAsync(advertsNew[0].Name);

            //assert
            advertsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddAdvert_ShouldReturn_Advert()
        {
            //arrange
            var advert = new Advert
            {
                Id = 11,
                Name = "Car 19990",
                Description = "Sell car 19990",
                Price = 10000,
                Date = System.DateTime.Now
            };

            var advertRepository = new AdvertRepository(context);

            //act
            var result = await advertRepository.CreateAdvertAsync(advert);

            //assert
            advert.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditAdvert_ShouldReturn_Advert()
        {
            //arrange
            ClearDatabase(context);

            var advertsNew = AddDb(context);
            var advertRepository = new AdvertRepository(context);

            //act
            var result = await advertRepository.EditAdvertAsync(advertsNew[0]);

            //assert
            advertsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteAdvert_ShouldReturn_Advert()
        {
            //arrange
            ClearDatabase(context);

            var advertsNew = AddDb(context);
            var advertRepository = new AdvertRepository(context);

            //act
            await advertRepository.DeleteAdvertAsync(advertsNew[1]);

            //assert
            Assert.True(context.Adverts.FirstOrDefault(t => t.Id == advertsNew[1].Id) == null);
        }

        private Advert[] AddDb(DatabaseContext database)
        {
            var advertsNew = new[] {

                new Advert
                {
                    Id = 1,
                    Name = "House",
                    Description = "Sell big house",
                    Price = 550000,
                    Date = System.DateTime.Now
                },

                new Advert
                {
                    Id = 12,
                    Name = "PC",
                    Description = "Sell good PC",
                    Price = 2000,
                    Date = System.DateTime.Now.AddDays(-1)
                }
            };

            database.Adverts.AddRange(advertsNew);
            database.SaveChanges();

            return advertsNew;
        }

        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Adverts)
                context.Adverts.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
