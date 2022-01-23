using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Advert;
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
    ///     Advert service test
    /// </summary>
    public class AdvertServiceTest
    {
        Mock<IAdvertRepository> advertRepositoryMock;

        public AdvertServiceTest()
        {
            advertRepositoryMock = new Mock<IAdvertRepository>();
        }

        [Fact]
        public async Task GetAdverts_ShouldReturn_Adverts()
        {
            //arrange
            var adverts = GetTestAdverts();

            advertRepositoryMock.Setup(r => r.GetAdvertsAsync()).Returns(Task.FromResult(adverts.Adapt<List<Advert>>()));

            AdvertService service = new AdvertService(advertRepositoryMock.Object);

            //act
            List<AdvertDto> result = await service.GetAdvertsAsync();

            //assert
            adverts.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAdvertById_ShouldReturn_Advert()
        {
            //arrange
            var adverts = GetTestAdverts();

            advertRepositoryMock.Setup(r => r.GetAdvertByIdAsync(adverts[0].Id)).Returns(Task.FromResult(adverts[0].Adapt<Advert>()));

            AdvertService service = new AdvertService(advertRepositoryMock.Object);

            //act
            AdvertDto result = await service.GetAdvertByIdAsync(adverts[0].Id);

            //assert
            adverts[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAdvertByName_ShouldReturn_Advert()
        {
            //arrange
            var adverts = GetTestAdverts();

            advertRepositoryMock.Setup(r => r.GetAdvertByNameAsync(adverts[0].Name)).Returns(Task.FromResult(adverts[0].Adapt<Advert>()));

            AdvertService service = new AdvertService(advertRepositoryMock.Object);

            //act
            AdvertDto result = await service.GetAdvertByNameAsync(adverts[0].Name);

            //assert
            adverts[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddAdvert_ShouldReturn_Advert()
        {
            //arrange
            AdvertDto advert = new AdvertDto()
            {
                Id = 11,
                Name = "Car123",
                Description = "Sell car 123",
                Price = 100000,
                Date = System.DateTime.Now
            };

            advertRepositoryMock.Setup(r => r.CreateAdvertAsync(advert.Adapt<Advert>())).Returns(Task.FromResult(advert.Adapt<Advert>()));

            AdvertService service = new AdvertService(advertRepositoryMock.Object);

            //act
            CreateAdvertResponseModel result = await service.CreateAdvertAsync(advert);

            //assert
            Assert.True(result.Type == BulletinBoard.Infrastructure.Enums.AdvertResponseType.Success);
        }

        private List<AdvertDto> GetTestAdverts()
        {
            List<AdvertDto> adverts = new List<AdvertDto>
            {
                new AdvertDto
                {
                    Id = 1,
                    Name = "House Blue",
                    Description = "Sell big blue house",
                    Price = 900000,
                    Date = System.DateTime.Now
                },
                new AdvertDto{
                    Id = 2,
                    Name = "Fast PC",
                    Description = "Sell fast PC, i5 7800, nVidia",
                    Price = 40000,
                    Date = System.DateTime.Now.AddHours(-2)
                }
            };

            return adverts;
        }
    }
}
