using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; } = string.Empty;
    }
}