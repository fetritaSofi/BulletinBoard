using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;

namespace BulletinBoard.Infrastructure.Models.Service.Section
{
    /// <summary>
    ///     Edit section response model
    /// </summary>
    public class EditSectionResponseModel
    {
        public SectionDto Section { get; set; }
        public SectionResponseType Type { get; set; }
    }
}
