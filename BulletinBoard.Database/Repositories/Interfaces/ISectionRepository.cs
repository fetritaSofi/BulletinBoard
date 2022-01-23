using BulletinBoard.Database.Models;

namespace BulletinBoard.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for section repository
    /// </summary>
    public interface ISectionRepository
    {
        /// <summary>
        ///     Get sections async
        /// </summary>
        /// <returns></returns>
        Task<List<Section>> GetSectionsAsync();

        /// <summary>
        ///     Get section by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Section> GetSectionByIdAsync(int id);

        /// <summary>
        ///     Get section by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Section> GetSectionByNameAsync(string name);

        /// <summary>
        ///     Create section async
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        Task<Section> CreateSectionAsync(Section section);

        /// <summary>
        ///     Edit section async
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        Task<Section> EditSectionAsync(Section section);

        /// <summary>
        ///     Delete section async
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        Task DeleteSectionAsync(Section section);
    }
}
