using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Advert;

namespace BulletinBoard.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for advert service
    /// </summary>
    public interface IAdvertService
    {
        /// <summary>
        ///     Get adverts async
        /// </summary>
        /// <returns></returns>
        Task<List<AdvertDto>> GetAdvertsAsync();

        /// <summary>
        ///     Get advert by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AdvertDto> GetAdvertByIdAsync(int id);

        /// <summary>
        ///     Get advert by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<AdvertDto> GetAdvertByNameAsync(string name);

        /// <summary>
        ///     Create advert async
        /// </summary>
        /// <param name="advert"></param>
        /// <returns></returns>
        Task<CreateAdvertResponseModel> CreateAdvertAsync(AdvertDto advertDto);

        /// <summary>
        ///     Edit advert async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="advert"></param>
        /// <returns></returns>
        Task<EditAdvertResponseModel> EditAdvertAsync(int id, AdvertDto advertDto);

        /// <summary>
        ///     Delete advert async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AdvertResponseType> DeleteAdvertAsync(int id);
    }
}
