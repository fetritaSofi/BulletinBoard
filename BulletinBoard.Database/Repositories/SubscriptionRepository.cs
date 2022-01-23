using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Database.Repositories
{
    /// <summary>
    ///     Subscription repository
    /// </summary>
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SubscriptionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get subscriptions async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Subscription>> GetSubscriptionsAsync()
        {
            return await _databaseContext.Subscriptions.ToListAsync();
        }

        /// <summary>
        ///     Get subscription by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Subscription> GetSubscriptionByIdAsync(int id)
        {
            return await _databaseContext.Subscriptions.FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        ///     Create subscription async
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        public async Task<Subscription> CreateSubscriptionAsync(Subscription subscription)
        {
            _databaseContext.Subscriptions.Add(subscription);
            await _databaseContext.SaveChangesAsync();

            return subscription;
        }

        /// <summary>
        ///     Edit subscription async
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        public async Task<Subscription> EditSubscriptionAsync(Subscription subscription)
        {
            _databaseContext.Subscriptions.Update(subscription);
            await _databaseContext.SaveChangesAsync();

            return subscription;
        }

        /// <summary>
        ///     Delete subscription async
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        public async Task DeleteSubscriptionAsync(Subscription subscription)
        {
            _databaseContext.Subscriptions.Remove(subscription);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
