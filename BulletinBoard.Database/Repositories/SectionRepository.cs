using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Database.Repositories
{
    /// <summary>
    ///     Section repository
    /// </summary>
    public class SectionRepository : ISectionRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SectionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get sections async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Section>> GetSectionsAsync()
        {
            return await _databaseContext.Sections.ToListAsync();
        }

        /// <summary>
        ///     Get section by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Section> GetSectionByIdAsync(int id)
        {
            return await _databaseContext.Sections.FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        ///     Get section by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Section> GetSectionByNameAsync(string name)
        {
            return await _databaseContext.Sections.FirstOrDefaultAsync(s => s.Name == name);
        }

        /// <summary>
        ///     Create section async
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public async Task<Section> CreateSectionAsync(Section section)
        {
            _databaseContext.Sections.Add(section);
            await _databaseContext.SaveChangesAsync();

            return section;
        }

        /// <summary>
        ///     Edit section async
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public async Task<Section> EditSectionAsync(Section section)
        {
            _databaseContext.Sections.Update(section);
            await _databaseContext.SaveChangesAsync();

            return section;
        }

        /// <summary>
        ///     Delete section async
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public async Task DeleteSectionAsync(Section section)
        {
            _databaseContext.Sections.Remove(section);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
