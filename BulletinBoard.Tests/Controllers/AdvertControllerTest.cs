using BulletinBoard.Controllers;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using BulletinBoard.Infrastructure.Models.Service.Advert;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     Advert controller test
    /// </summary>
    public class AdvertControllerTest
    {
        Mock<IAdvertService> advertServiceMock;

        public AdvertControllerTest()
        {
            advertServiceMock = new Mock<IAdvertService>();
        }

        [Fact]
        public async Task GetAdverts_ShouldReturn_Adverts()
        {
            //arrange
            List<AdvertDto> adverts = GetTestAdverts();

            advertServiceMock.Setup(r => r.GetAdvertsAsync()).Returns(Task.FromResult(adverts));

            AdvertController controller = new AdvertController(advertServiceMock.Object);

            //act
            IActionResult? result = await controller.GetAdverts();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAdvertById_ShouldReturn_Advert()
        {
            //arrange
            var adverts = GetTestAdverts();

            advertServiceMock.Setup(r => r.GetAdvertByIdAsync(adverts[0].Id)).Returns(Task.FromResult(adverts[0]));

            AdvertController controller = new AdvertController(advertServiceMock.Object);

            //act
            IActionResult? result = await controller.GetAdvert(adverts[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddAdvert_ShouldReturn_Advert()
        {
            //arrange
            AdvertDto advert = new AdvertDto()
            {
                Id = 11,
                Name = "Car 321",
                Description = "Good car for city",
                Price = 10000000,
                Date = DateTime.Now
            };

            advertServiceMock.Setup(r => r.CreateAdvertAsync(advert)).Returns(Task.FromResult(new CreateAdvertResponseModel() {Advert = advert, Type = BulletinBoard.Infrastructure.Enums.AdvertResponseType.Success }));

            AdvertController controller = new AdvertController(advertServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(advert);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private List<AdvertDto> GetTestAdverts()
        {
            List<AdvertDto> adverts = new List<AdvertDto>
            {
                new AdvertDto
                {
                    Id = 1,
                    Name = "House Red",
                    Description = "Good house in city",
                    Price = 90000000,
                    Date = DateTime.Now
                },

                new AdvertDto
                {
                    Id = 2,
                    Name = "PC",
                    Description = "Good pc for games",
                    Price = 4000,
                    Date = DateTime.Now
                }
            };

            return adverts;
        }
    }
}
