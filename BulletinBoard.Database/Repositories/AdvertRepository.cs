using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Database.Repositories
{
    /// <summary>
    ///     Advert repository
    /// </summary>
    public class AdvertRepository : IAdvertRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AdvertRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get adverts async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Advert>> GetAdvertsAsync()
        {
            return await _databaseContext.Adverts.ToListAsync();
        }

        /// <summary>
        ///     Get advert by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Advert> GetAdvertByIdAsync(int id)
        {
            return await _databaseContext.Adverts.FirstOrDefaultAsync(a => a.Id == id);
        }

        /// <summary>
        ///     Get advert by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Advert> GetAdvertByNameAsync(string name)
        {
            return await _databaseContext.Adverts.FirstOrDefaultAsync(a => a.Name == name);
        }

        /// <summary>
        ///     Create advert async
        /// </summary>
        /// <param name="advert"></param>
        /// <returns></returns>
        public async Task<Advert> CreateAdvertAsync(Advert advert)
        {
            _databaseContext.Adverts.Add(advert);
            await _databaseContext.SaveChangesAsync();

            return advert;
        }

        /// <summary>
        ///     Edit advert async
        /// </summary>
        /// <param name="advert"></param>
        /// <returns></returns>
        public async Task<Advert> EditAdvertAsync(Advert advert)
        {
            _databaseContext.Adverts.Update(advert);
            await _databaseContext.SaveChangesAsync();

            return advert;
        }

        /// <summary>
        ///     Delete advert async
        /// </summary>
        /// <param name="advert"></param>
        /// <returns></returns>
        public async Task DeleteAdvertAsync(Advert advert)
        {
            _databaseContext.Adverts.Remove(advert);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
