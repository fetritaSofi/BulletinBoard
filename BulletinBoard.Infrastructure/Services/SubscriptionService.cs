using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Subscription;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Mapster;

namespace BulletinBoard.Infrastructure.Services
{
    /// <summary>
    ///     Subscription service
    /// </summary>
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        ///     Get subscriptions async
        /// </summary>
        /// <returns></returns>
        public async Task<List<SubscriptionDto>> GetSubscriptionsAsync()
        {
            List<Subscription> Subscriptions = await _subscriptionRepository.GetSubscriptionsAsync();
            return Subscriptions.Adapt<List<SubscriptionDto>>();
        }

        /// <summary>
        ///     Get subscription by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SubscriptionDto> GetSubscriptionByIdAsync(int id)
        {
            Subscription Subscriptions = await _subscriptionRepository.GetSubscriptionByIdAsync(id);
            return Subscriptions.Adapt<SubscriptionDto>();
        }

        /// <summary>
        ///     Create subscription async
        /// </summary>
        /// <param name="Subscription"></param>
        /// <returns></returns>
        public async Task<CreateSubscriptionResponseModel> CreateSubscriptionAsync(SubscriptionDto SubscriptionDto)
        {
            User user = await _userRepository.GetUserByIdAsync(SubscriptionDto.UserId);

            if (user == null)
            {
                return new CreateSubscriptionResponseModel()
                {
                    Type = SubscriptionResponseType.UserNotFound
                };
            }

            Subscription Subscription = SubscriptionDto.Adapt<Subscription>();
            Subscription SubscriptionCreated = await _subscriptionRepository.CreateSubscriptionAsync(Subscription);

            return new CreateSubscriptionResponseModel()
            {
                Subscription = SubscriptionCreated.Adapt<SubscriptionDto>(),
                Type = SubscriptionResponseType.Success
            };
        }

        /// <summary>
        ///     Edit subscription async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Subscription"></param>
        /// <returns></returns>
        public async Task<EditSubscriptionResponseModel> EditSubscriptionAsync(int id, SubscriptionDto SubscriptionDto)
        {
            Subscription Subscription = await _subscriptionRepository.GetSubscriptionByIdAsync(id);

            if (Subscription == null)
            {
                return new EditSubscriptionResponseModel()
                {
                    Type = SubscriptionResponseType.SubscriptionNotFound
                };
            }

            SubscriptionDto.Id = Subscription.Id;

            Subscription SubscriptionModel = SubscriptionDto.Adapt<Subscription>();
            Subscription SubscriptionEdited = await _subscriptionRepository.EditSubscriptionAsync(SubscriptionModel);

            return new EditSubscriptionResponseModel()
            {
                Subscription = SubscriptionEdited.Adapt<SubscriptionDto>(),
                Type = SubscriptionResponseType.Success
            };
        }

        /// <summary>
        ///     Delete subscription async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SubscriptionResponseType> DeleteSubscriptionAsync(int id)
        {
            Subscription Subscription = await _subscriptionRepository.GetSubscriptionByIdAsync(id);

            if (Subscription == null)
            {
                return SubscriptionResponseType.SubscriptionNotFound;
            }

            await _subscriptionRepository.DeleteSubscriptionAsync(Subscription);

            return SubscriptionResponseType.Success;
        }
    }
}

