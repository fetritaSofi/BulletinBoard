namespace BulletinBoard.Database.Models
{
    /// <summary>
    ///     Section model
    /// </summary>
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Advert> Adverts { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
