namespace BulletinBoard.Database.Models
{
    /// <summary>
    ///     Subscription model
    /// </summary>
    public class Subscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateView { get; set; }

        public User User { get; set; }
        public List<Section> Sections { get; set; }
    }
}
