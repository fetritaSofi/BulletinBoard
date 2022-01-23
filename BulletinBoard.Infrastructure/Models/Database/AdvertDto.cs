namespace BulletinBoard.Infrastructure.Models.Database
{
    /// <summary>
    ///     Advert dto
    /// </summary>
    public class AdvertDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
