using BulletinBoard.Database.Models;
using BulletinBoard.Database.Repositories.Interfaces;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Subscription;
using BulletinBoard.Infrastructure.Services;
using FluentAssertions;
using Mapster;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Timetable.Tests.Services
{
    /// <summary>
    ///     Subscription service test
    /// </summary>
    public class SubscriptionServiceTest
    {
        Mock<ISubscriptionRepository> subscriptionRepositoryMock;
        Mock<IUserRepository> userRepositoryMock;

        public SubscriptionServiceTest()
        {
            subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task GetSubscriptions_ShouldReturn_Subscriptions()
        {
            //arrange
            var subscriptions = GetTestSubscriptions();

            subscriptionRepositoryMock.Setup(r => r.GetSubscriptionsAsync()).Returns(Task.FromResult(subscriptions.Adapt<List<Subscription>>()));

            SubscriptionService service = new SubscriptionService(subscriptionRepositoryMock.Object, userRepositoryMock.Object);

            //act
            List<SubscriptionDto> result = await service.GetSubscriptionsAsync();

            //assert
            subscriptions.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSubscriptionById_ShouldReturn_Subscription()
        {
            //arrange
            var subscriptions = GetTestSubscriptions();

            subscriptionRepositoryMock.Setup(r => r.GetSubscriptionByIdAsync(subscriptions[0].Id)).Returns(Task.FromResult(subscriptions[0].Adapt<Subscription>()));

            SubscriptionService service = new SubscriptionService(subscriptionRepositoryMock.Object, userRepositoryMock.Object);

            //act
            SubscriptionDto result = await service.GetSubscriptionByIdAsync(subscriptions[0].Id);

            //assert
            subscriptions[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddSubscription_ShouldReturn_Subscription()
        {
            //arrange
            SubscriptionDto subscription = new SubscriptionDto()
            {
                Id = 11,
                UserId = 11,
                DateView = DateTime.Now
            };

            UserDto user = new UserDto()
            {
                Id = 11,
                Name = "John",
                Email =  "qwe@qwe.qwe",
                Password = "123"
            };

            subscriptionRepositoryMock.Setup(r => r.CreateSubscriptionAsync(subscription.Adapt<Subscription>())).Returns(Task.FromResult(subscription.Adapt<Subscription>()));
            userRepositoryMock.Setup(r => r.GetUserByIdAsync(user.Id)).Returns(Task.FromResult(user.Adapt<User>()));

            SubscriptionService service = new SubscriptionService(subscriptionRepositoryMock.Object, userRepositoryMock.Object);

            //act
            CreateSubscriptionResponseModel result = await service.CreateSubscriptionAsync(subscription);

            //assert
            Assert.True(result.Type == BulletinBoard.Infrastructure.Enums.SubscriptionResponseType.Success);
        }

        private List<SubscriptionDto> GetTestSubscriptions()
        {
            List<SubscriptionDto> subscriptions = new List<SubscriptionDto>
            {
                new SubscriptionDto
                {
                    Id = 1,
                    UserId = 1,
                    DateView = DateTime.Now.AddDays(-1)
                },
                new SubscriptionDto{
                    Id = 2,
                    UserId = 1,
                    DateView = DateTime.Now.AddHours(-1)
                }
            };

            return subscriptions;
        }
    }
}
