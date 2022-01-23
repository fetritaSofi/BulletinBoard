using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;

namespace BulletinBoard.Infrastructure.Models.Service.Advert
{
    /// <summary>
    ///     Edit advert response model
    /// </summary>
    public class EditAdvertResponseModel
    {
        public AdvertDto Advert { get; set; }
        public AdvertResponseType Type { get; set; }
    }
}
