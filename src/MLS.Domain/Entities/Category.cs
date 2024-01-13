using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Category : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
