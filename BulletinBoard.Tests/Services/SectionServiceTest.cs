using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Section;
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
    ///     Section service test
    /// </summary>
    public class SectionServiceTest
    {
        Mock<ISectionRepository> sectionRepositoryMock;

        public SectionServiceTest()
        {
            sectionRepositoryMock = new Mock<ISectionRepository>();
        }

        [Fact]
        public async Task GetSections_ShouldReturn_Sections()
        {
            //arrange
            var sections = GetTestSections();

            sectionRepositoryMock.Setup(r => r.GetSectionsAsync()).Returns(Task.FromResult(sections.Adapt<List<Section>>()));

            SectionService service = new SectionService(sectionRepositoryMock.Object);

            //act
            List<SectionDto> result = await service.GetSectionsAsync();

            //assert
            sections.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSectionById_ShouldReturn_Section()
        {
            //arrange
            var sections = GetTestSections();

            sectionRepositoryMock.Setup(r => r.GetSectionByIdAsync(sections[0].Id)).Returns(Task.FromResult(sections[0].Adapt<Section>()));

            SectionService service = new SectionService(sectionRepositoryMock.Object);

            //act
            SectionDto result = await service.GetSectionByIdAsync(sections[0].Id);

            //assert
            sections[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSectionByName_ShouldReturn_Section()
        {
            //arrange
            var sections = GetTestSections();

            sectionRepositoryMock.Setup(r => r.GetSectionByNameAsync(sections[0].Name)).Returns(Task.FromResult(sections[0].Adapt<Section>()));

            SectionService service = new SectionService(sectionRepositoryMock.Object);

            //act
            SectionDto result = await service.GetSectionByNameAsync(sections[0].Name);

            //assert
            sections[0].Should().BeEquivalentTo(result);
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

            sectionRepositoryMock.Setup(r => r.CreateSectionAsync(section.Adapt<Section>())).Returns(Task.FromResult(section.Adapt<Section>()));

            SectionService service = new SectionService(sectionRepositoryMock.Object);

            //act
            CreateSectionResponseModel result = await service.CreateSectionAsync(section);

            //assert
            Assert.True(result.Type == BulletinBoard.Infrastructure.Enums.SectionResponseType.Success);
        }

        private List<SectionDto> GetTestSections()
        {
            List<SectionDto> sections = new List<SectionDto>
            {
                new SectionDto
                {
                    Id = 1,
                    Name = "House",
                },
                new SectionDto{
                    Id = 2,
                    Name = "PC",
                }
            };

            return sections;
        }
    }
}
