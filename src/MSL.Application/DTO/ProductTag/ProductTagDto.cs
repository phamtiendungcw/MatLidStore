namespace MLS.Application.DTO.ProductTag
{
    public class ProductTagDto
    {
        public int ProductTagId { get; set; }
        public string TagName { get; set; }
        public int ProductId { get; set; } // Product ID (for foreign key reference)
        public int TagId { get; set; } // Tag ID (for foreign key reference)
    }
}