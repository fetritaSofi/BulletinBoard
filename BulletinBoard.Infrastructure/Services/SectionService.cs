using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Section;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Mapster;

namespace BulletinBoard.Infrastructure.Services
{
    /// <summary>
    ///     Section service
    /// </summary>
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        /// <summary>
        ///     Get sections async
        /// </summary>
        /// <returns></returns>
        public async Task<List<SectionDto>> GetSectionsAsync()
        {
            List<Section> sections = await _sectionRepository.GetSectionsAsync();
            return sections.Adapt<List<SectionDto>>();
        }

        /// <summary>
        ///     Get section by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SectionDto> GetSectionByIdAsync(int id)
        {
            Section sections = await _sectionRepository.GetSectionByIdAsync(id);
            return sections.Adapt<SectionDto>();
        }

        /// <summary>
        ///     Get section by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SectionDto> GetSectionByNameAsync(string name)
        {
            Section sections = await _sectionRepository.GetSectionByNameAsync(name);
            return sections.Adapt<SectionDto>();
        }

        /// <summary>
        ///     Create section async
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public async Task<CreateSectionResponseModel> CreateSectionAsync(SectionDto sectionDto)
        {
            Section section = sectionDto.Adapt<Section>();
            Section sectionCreated = await _sectionRepository.CreateSectionAsync(section);

            return new CreateSectionResponseModel()
            {
                Section = sectionCreated.Adapt<SectionDto>(),
                Type = SectionResponseType.Success
            };
        }

        /// <summary>
        ///     Edit section async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public async Task<EditSectionResponseModel> EditSectionAsync(int id, SectionDto sectionDto)
        {
            Section section = await _sectionRepository.GetSectionByIdAsync(id);

            if (section == null)
            {
                return new EditSectionResponseModel()
                {
                    Type = SectionResponseType.SectionNotFound
                };
            }

            sectionDto.Id = section.Id;

            Section sectionModel = sectionDto.Adapt<Section>();
            Section sectionEdited = await _sectionRepository.EditSectionAsync(sectionModel);

            return new EditSectionResponseModel()
            {
                Section = sectionEdited.Adapt<SectionDto>(),
                Type = SectionResponseType.Success
            };
        }

        /// <summary>
        ///     Delete section async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SectionResponseType> DeleteSectionAsync(int id)
        {
            Section section = await _sectionRepository.GetSectionByIdAsync(id);

            if (section == null)
            {
                return SectionResponseType.SectionNotFound;
            }

            await _sectionRepository.DeleteSectionAsync(section);

            return SectionResponseType.Success;
        }
    }
}

