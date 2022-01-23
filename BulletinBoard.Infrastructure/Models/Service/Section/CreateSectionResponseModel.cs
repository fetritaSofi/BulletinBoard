using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;

namespace BulletinBoard.Infrastructure.Models.Service.Section
{
    /// <summary>
    ///     Create section response model
    /// </summary>
    public class CreateSectionResponseModel
    {
        public SectionDto Section { get; set; }
        public SectionResponseType Type { get; set; }
    }
}
