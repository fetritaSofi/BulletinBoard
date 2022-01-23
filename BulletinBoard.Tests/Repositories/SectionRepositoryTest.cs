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
    ///     Section repository test
    /// </summary>
    public class SectionRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public SectionRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetSections_ShouldReturn_Sections()
        {
            //arange
            ClearDatabase(context);

            var sectionsNew = AddDb(context);

            var sectionRepository = new SectionRepository(context);

            //act
            var result = await sectionRepository.GetSectionsAsync();

            //assert
            sectionsNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSectionById_ShouldReturn_Section()
        {
            //arrange
            ClearDatabase(context);

            var sectionsNew = AddDb(context);

            var sectionRepository = new SectionRepository(context);

            //act
            var result = await sectionRepository.GetSectionByIdAsync(sectionsNew[0].Id);

            //assert
            sectionsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSectionByName_ShouldReturn_Section()
        {
            //arrange
            ClearDatabase(context);

            var sectionsNew = AddDb(context);

            var sectionRepository = new SectionRepository(context);

            //act
            var result = await sectionRepository.GetSectionByNameAsync(sectionsNew[0].Name);

            //assert
            sectionsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddSection_ShouldReturn_Section()
        {
            //arrange
            var section = new Section
            {
                Id = 11,
                Name = "Car",
            };

            var sectionRepository = new SectionRepository(context);

            //act
            var result = await sectionRepository.CreateSectionAsync(section);

            //assert
            section.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditSection_ShouldReturn_Section()
        {
            //arrange
            ClearDatabase(context);

            var sectionsNew = AddDb(context);
            var sectionRepository = new SectionRepository(context);

            //act
            var result = await sectionRepository.EditSectionAsync(sectionsNew[0]);

            //assert
            sectionsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteSection_ShouldReturn_Section()
        {
            //arrange
            ClearDatabase(context);

            var sectionsNew = AddDb(context);
            var sectionRepository = new SectionRepository(context);

            //act
            await sectionRepository.DeleteSectionAsync(sectionsNew[1]);

            //assert
            Assert.True(context.Sections.FirstOrDefault(t => t.Id == sectionsNew[1].Id) == null);
        }

        private Section[] AddDb(DatabaseContext database)
        {
            var sectionsNew = new[] {

                new Section
                {
                    Id = 1,
                    Name = "House"
                },

                new Section
                {
                    Id = 2,
                    Name = "PC"
                }
            };

            database.Sections.AddRange(sectionsNew);
            database.SaveChanges();

            return sectionsNew;
        }

        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Sections)
                context.Sections.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
