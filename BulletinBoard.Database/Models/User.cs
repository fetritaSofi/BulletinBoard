namespace BulletinBoard.Database.Models
{
    /// <summary>
    ///     User model
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }

        public List<Subscription> Subscriptions { get; set; }
    }
}
