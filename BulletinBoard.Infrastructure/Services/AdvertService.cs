using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Advert;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Mapster;

namespace BulletinBoard.Infrastructure.Services
{
    /// <summary>
    ///     Advert service
    /// </summary>
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;

        public AdvertService(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        /// <summary>
        ///     Get adverts async
        /// </summary>
        /// <returns></returns>
        public async Task<List<AdvertDto>> GetAdvertsAsync()
        {
            List<Advert> adverts = await _advertRepository.GetAdvertsAsync();
            return adverts.Adapt<List<AdvertDto>>();
        }

        /// <summary>
        ///     Get advert by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AdvertDto> GetAdvertByIdAsync(int id)
        {
            Advert adverts = await _advertRepository.GetAdvertByIdAsync(id);
            return adverts.Adapt<AdvertDto>();
        }

        /// <summary>
        ///     Get advert by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<AdvertDto> GetAdvertByNameAsync(string name)
        {
            Advert adverts = await _advertRepository.GetAdvertByNameAsync(name);
            return adverts.Adapt<AdvertDto>();
        }

        /// <summary>
        ///     Create advert async
        /// </summary>
        /// <param name="advert"></param>
        /// <returns></returns>
        public async Task<CreateAdvertResponseModel> CreateAdvertAsync(AdvertDto advertDto)
        {
            Advert advert = advertDto.Adapt<Advert>();
            Advert advertCreated = await _advertRepository.CreateAdvertAsync(advert);

            return new CreateAdvertResponseModel()
            {
                Advert = advertCreated.Adapt<AdvertDto>(),
                Type = AdvertResponseType.Success
            };
        }

        /// <summary>
        ///     Edit advert async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="advert"></param>
        /// <returns></returns>
        public async Task<EditAdvertResponseModel> EditAdvertAsync(int id, AdvertDto advertDto)
        {
            Advert advert = await _advertRepository.GetAdvertByIdAsync(id);

            if (advert == null)
            {
                return new EditAdvertResponseModel()
                {
                    Type = AdvertResponseType.AdvertNotFound
                };
            }

            advertDto.Id = advert.Id;

            Advert advertModel = advertDto.Adapt<Advert>();
            Advert advertEdited = await _advertRepository.EditAdvertAsync(advertModel);

            return new EditAdvertResponseModel()
            {
                Advert = advertEdited.Adapt<AdvertDto>(),
                Type = AdvertResponseType.Success
            };
        }

        /// <summary>
        ///     Delete advert async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AdvertResponseType> DeleteAdvertAsync(int id)
        {
            Advert advert = await _advertRepository.GetAdvertByIdAsync(id);

            if (advert == null)
            {
                return AdvertResponseType.AdvertNotFound;
            }

            await _advertRepository.DeleteAdvertAsync(advert);

            return AdvertResponseType.Success;
        }
    }
}

