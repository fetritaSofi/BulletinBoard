using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;

namespace BulletinBoard.Infrastructure.Models.Service.Advert
{
    /// <summary>
    ///     Create advert response model
    /// </summary>
    public class CreateAdvertResponseModel
    {
        public AdvertDto Advert { get; set; }
        public AdvertResponseType Type { get; set; }
    }
}
