using BulletinBoard.Database.Models;

namespace BulletinBoard.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for advert repository
    /// </summary>
    public interface IAdvertRepository
    {
        /// <summary>
        ///     Get adverts async
        /// </summary>
        /// <returns></returns>
        Task<List<Advert>> GetAdvertsAsync();

        /// <summary>
        ///     Get advert by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Advert> GetAdvertByIdAsync(int id);
        
        /// <summary>
        ///     Get advert by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Advert> GetAdvertByNameAsync(string name);
        
        /// <summary>
        ///     Create advert async
        /// </summary>
        /// <param name="advert"></param>
        /// <returns></returns>
        Task<Advert> CreateAdvertAsync(Advert advert);
       
        /// <summary>
        ///     Edit advert async
        /// </summary>
        /// <param name="advert"></param>
        /// <returns></returns>
        Task<Advert> EditAdvertAsync(Advert advert);

        /// <summary>
        ///     Delete advert async
        /// </summary>
        /// <param name="advert"></param>
        /// <returns></returns>
        Task DeleteAdvertAsync(Advert advert);
    }
}
