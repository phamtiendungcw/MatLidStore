using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductColor : BaseEntity
    {
        public string ColorName { get; set; } // Color name (e.g., "Red", "Blue")
        public string ColorHexCode { get; set; } // Hexadecimal color code (#FF0000, #0000FF)

        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } // Navigation property for Product
    }
}