using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Subscription;

namespace BulletinBoard.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for subscription service
    /// </summary>
    public interface ISubscriptionService
    {
        /// <summary>
        ///     Get Subscriptions async
        /// </summary>
        /// <returns></returns>
        Task<List<SubscriptionDto>> GetSubscriptionsAsync();

        /// <summary>
        ///     Get Subscription by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SubscriptionDto> GetSubscriptionByIdAsync(int id);

        /// <summary>
        ///     Create Subscription async
        /// </summary>
        /// <param name="Subscription"></param>
        /// <returns></returns>
        Task<CreateSubscriptionResponseModel> CreateSubscriptionAsync(SubscriptionDto SubscriptionDto);

        /// <summary>
        ///     Edit Subscription async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Subscription"></param>
        /// <returns></returns>
        Task<EditSubscriptionResponseModel> EditSubscriptionAsync(int id, SubscriptionDto SubscriptionDto);

        /// <summary>
        ///     Delete Subscription async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SubscriptionResponseType> DeleteSubscriptionAsync(int id);
    }
}
