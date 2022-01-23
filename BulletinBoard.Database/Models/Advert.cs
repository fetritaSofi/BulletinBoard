namespace BulletinBoard.Database.Models
{
    /// <summary>
    ///     Advert model
    /// </summary>
    public class Advert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public List<Section> Sections { get; set; }
    }
}
