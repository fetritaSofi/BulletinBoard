using BulletinBoard.Database.Models;

namespace BulletinBoard.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for subscription repository
    /// </summary>
    public interface ISubscriptionRepository
    {
        /// <summary>
        ///     Get subscriptions async
        /// </summary>
        /// <returns></returns>
        Task<List<Subscription>> GetSubscriptionsAsync();

        /// <summary>
        ///     Get subscription by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Subscription> GetSubscriptionByIdAsync(int id);

        /// <summary>
        ///     Create subscription async
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        Task<Subscription> CreateSubscriptionAsync(Subscription subscription);

        /// <summary>
        ///     Edit subscription async
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        Task<Subscription> EditSubscriptionAsync(Subscription subscription);

        /// <summary>
        ///     Delete subscription async
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        Task DeleteSubscriptionAsync(Subscription subscription);
    }
}
