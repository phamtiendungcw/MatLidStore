using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}