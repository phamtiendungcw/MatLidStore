using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class News : BaseEntity
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
