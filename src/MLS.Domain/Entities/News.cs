using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
    }
}
