namespace MLS.Application.DTO.ProductImage
{
    public class UpdateProductImageDto
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageDescription { get; set; }
        public int? ProductId { get; set; }
    }
}