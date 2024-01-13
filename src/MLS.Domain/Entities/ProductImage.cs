using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
    }
}
