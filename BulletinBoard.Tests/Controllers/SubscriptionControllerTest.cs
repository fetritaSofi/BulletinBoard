using BulletinBoard.Controllers;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using BulletinBoard.Infrastructure.Models.Service.Subscription;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     Subscription controller test
    /// </summary>
    public class SubscriptionControllerTest
    {
        Mock<ISubscriptionService> subscriptionServiceMock;

        public SubscriptionControllerTest()
        {
            subscriptionServiceMock = new Mock<ISubscriptionService>();
        }

        [Fact]
        public async Task GetSubscriptions_ShouldReturn_Subscriptions()
        {
            //arrange
            List<SubscriptionDto> subscriptions = GetTestSubscriptions();

            subscriptionServiceMock.Setup(r => r.GetSubscriptionsAsync()).Returns(Task.FromResult(subscriptions));

            SubscriptionController controller = new SubscriptionController(subscriptionServiceMock.Object);

            //act
            IActionResult? result = await controller.GetSubscriptions();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetSubscriptionById_ShouldReturn_Subscription()
        {
            //arrange
            var subscriptions = GetTestSubscriptions();

            subscriptionServiceMock.Setup(r => r.GetSubscriptionByIdAsync(subscriptions[0].Id)).Returns(Task.FromResult(subscriptions[0]));

            SubscriptionController controller = new SubscriptionController(subscriptionServiceMock.Object);

            //act
            IActionResult? result = await controller.GetSubscription(subscriptions[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddSubscription_ShouldReturn_Subscription()
        {
            //arrange
            SubscriptionDto subscription = new SubscriptionDto()
            {
                Id = 11,
                UserId = 11,
            };

            subscriptionServiceMock.Setup(r => r.CreateSubscriptionAsync(subscription)).Returns(Task.FromResult(new CreateSubscriptionResponseModel() {Subscription = subscription, Type = BulletinBoard.Infrastructure.Enums.SubscriptionResponseType.Success }));

            SubscriptionController controller = new SubscriptionController(subscriptionServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(subscription);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
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

                new SubscriptionDto
                {
                    Id = 2,
                    UserId = 1,
                    DateView = DateTime.Now.AddHours(-1)
                }
            };

            return subscriptions;
        }
    }
}
