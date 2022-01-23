using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Subscription;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("GetSubscriptions")]
        public async Task<IActionResult> GetSubscriptions()
        {
            List<SubscriptionDto> subscriptions = await _subscriptionService.GetSubscriptionsAsync();

            return Ok(subscriptions);
        }

        [HttpGet("GetSubscription/{id}")]
        public async Task<IActionResult> GetSubscription(int id)
        {
            SubscriptionDto subscription = await _subscriptionService.GetSubscriptionByIdAsync(id);

            return Ok(subscription);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubscriptionDto subscription)
        {
            CreateSubscriptionResponseModel createSubscriptionResponse = await _subscriptionService.CreateSubscriptionAsync(subscription);

            if (createSubscriptionResponse.Type == SubscriptionResponseType.Success)
            {
                return Ok(createSubscriptionResponse);
            }

            return BadRequest(createSubscriptionResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, SubscriptionDto subscription)
        {
            EditSubscriptionResponseModel editSubscriptionResponse = await _subscriptionService.EditSubscriptionAsync(id, subscription);

            if (editSubscriptionResponse.Type == SubscriptionResponseType.Success)
            {
                return Ok(editSubscriptionResponse);
            }

            return BadRequest(editSubscriptionResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            SubscriptionResponseType subscriptionResponse = await _subscriptionService.DeleteSubscriptionAsync(id);

            if (subscriptionResponse == SubscriptionResponseType.Success)
            {
                return Ok(subscriptionResponse);
            }

            return BadRequest(subscriptionResponse);
        }
    }
}
