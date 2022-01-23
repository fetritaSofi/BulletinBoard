namespace BulletinBoard.Infrastructure.Models.Database
{
    /// <summary>
    ///     Subscription dto
    /// </summary>
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateView { get; set; }
    }
}
