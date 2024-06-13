namespace MLS.Application.DTO.ProductImage
{
    public class ProductImageDto
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageDescription { get; set; }
        public int ProductId { get; set; } // Product ID (for foreign key reference)
    }
}