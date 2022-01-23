using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;

namespace BulletinBoard.Infrastructure.Models.Service.Subscription
{
    /// <summary>
    ///     Edit subscription response model
    /// </summary>
    public class EditSubscriptionResponseModel
    {
        public SubscriptionDto Subscription { get; set; }
        public SubscriptionResponseType Type { get; set; }
    }
}
