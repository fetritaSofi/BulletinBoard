using BulletinBoard.Controllers;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using BulletinBoard.Infrastructure.Models.Service.Section;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     Section controller test
    /// </summary>
    public class SectionControllerTest
    {
        Mock<ISectionService> sectionServiceMock;

        public SectionControllerTest()
        {
            sectionServiceMock = new Mock<ISectionService>();
        }

        [Fact]
        public async Task GetSections_ShouldReturn_Sections()
        {
            //arrange
            List<SectionDto> sections = GetTestSections();

            sectionServiceMock.Setup(r => r.GetSectionsAsync()).Returns(Task.FromResult(sections));

            SectionController controller = new SectionController(sectionServiceMock.Object);

            //act
            IActionResult? result = await controller.GetSections();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetSectionById_ShouldReturn_Section()
        {
            //arrange
            var sections = GetTestSections();

            sectionServiceMock.Setup(r => r.GetSectionByIdAsync(sections[0].Id)).Returns(Task.FromResult(sections[0]));

            SectionController controller = new SectionController(sectionServiceMock.Object);

            //act
            IActionResult? result = await controller.GetSection(sections[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddSection_ShouldReturn_Section()
        {
            //arrange
            SectionDto section = new SectionDto()
            {
                Id = 11,
                Name = "Car",
            };

            sectionServiceMock.Setup(r => r.CreateSectionAsync(section)).Returns(Task.FromResult(new CreateSectionResponseModel() {Section = section, Type = BulletinBoard.Infrastructure.Enums.SectionResponseType.Success }));

            SectionController controller = new SectionController(sectionServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(section);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private List<SectionDto> GetTestSections()
        {
            List<SectionDto> sections = new List<SectionDto>
            {
                new SectionDto
                {
                    Id = 1,
                    Name = "House"
                },

                new SectionDto
                {
                    Id = 2,
                    Name = "PC"
                }
            };

            return sections;
        }
    }
}
