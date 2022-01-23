using BulletinBoard.Database;
using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Timetable.Tests.Repositories
{
    /// <summary>
    ///     Subscription repository test
    /// </summary>
    public class SubscriptionRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public SubscriptionRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetSubscriptions_ShouldReturn_Subscriptions()
        {
            //arange
            ClearDatabase(context);

            var subscriptionsNew = AddDb(context);

            var subscriptionRepository = new SubscriptionRepository(context);

            //act
            var result = await subscriptionRepository.GetSubscriptionsAsync();

            //assert
            subscriptionsNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSubscriptionById_ShouldReturn_Subscription()
        {
            //arrange
            ClearDatabase(context);

            var subscriptionsNew = AddDb(context);

            var subscriptionRepository = new SubscriptionRepository(context);

            //act
            var result = await subscriptionRepository.GetSubscriptionByIdAsync(subscriptionsNew[0].Id);

            //assert
            subscriptionsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddSubscription_ShouldReturn_Subscription()
        {
            //arrange
            var subscription = new Subscription
            {
                Id = 11,
                UserId = 11,
                DateView = DateTime.Now
            };

            var subscriptionRepository = new SubscriptionRepository(context);

            //act
            var result = await subscriptionRepository.CreateSubscriptionAsync(subscription);

            //assert
            subscription.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditSubscription_ShouldReturn_Subscription()
        {
            //arrange
            ClearDatabase(context);

            var subscriptionsNew = AddDb(context);
            var subscriptionRepository = new SubscriptionRepository(context);

            //act
            var result = await subscriptionRepository.EditSubscriptionAsync(subscriptionsNew[0]);

            //assert
            subscriptionsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteSubscription_ShouldReturn_Subscription()
        {
            //arrange
            ClearDatabase(context);

            var subscriptionsNew = AddDb(context);
            var subscriptionRepository = new SubscriptionRepository(context);

            //act
            await subscriptionRepository.DeleteSubscriptionAsync(subscriptionsNew[1]);

            //assert
            Assert.True(context.Subscriptions.FirstOrDefault(t => t.Id == subscriptionsNew[1].Id) == null);
        }

        private Subscription[] AddDb(DatabaseContext database)
        {
            var subscriptionsNew = new[] {

                new Subscription
                {
                    Id = 1,
                    UserId = 1,
                    DateView = DateTime.Now.AddDays(-1)
                },

                new Subscription
                {
                    Id = 2,
                    UserId = 2,
                    DateView = DateTime.Now.AddHours(-1)
                }
            };

            database.Subscriptions.AddRange(subscriptionsNew);
            database.SaveChanges();

            return subscriptionsNew;
        }

        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Subscriptions)
                context.Subscriptions.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
