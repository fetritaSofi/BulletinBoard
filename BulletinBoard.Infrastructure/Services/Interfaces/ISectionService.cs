using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Section;

namespace BulletinBoard.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for section service
    /// </summary>
    public interface ISectionService
    {
        /// <summary>
        ///     Get sections async
        /// </summary>
        /// <returns></returns>
        Task<List<SectionDto>> GetSectionsAsync();

        /// <summary>
        ///     Get section by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SectionDto> GetSectionByIdAsync(int id);

        /// <summary>
        ///     Get section by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<SectionDto> GetSectionByNameAsync(string name);

        /// <summary>
        ///     Create section async
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        Task<CreateSectionResponseModel> CreateSectionAsync(SectionDto sectionDto);

        /// <summary>
        ///     Edit section async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        Task<EditSectionResponseModel> EditSectionAsync(int id, SectionDto sectionDto);

        /// <summary>
        ///     Delete section async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SectionResponseType> DeleteSectionAsync(int id);
    }
}
