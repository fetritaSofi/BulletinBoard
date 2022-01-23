using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;

namespace BulletinBoard.Infrastructure.Models.Service.Subscription
{
    /// <summary>
    ///     Create subscription response model
    /// </summary>
    public class CreateSubscriptionResponseModel
    {
        public SubscriptionDto Subscription { get; set; }
        public SubscriptionResponseType Type { get; set; }
    }
}
