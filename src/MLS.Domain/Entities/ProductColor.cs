using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductColor : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; } // Hex code for color, e.g., #FFFFFF
    }
}