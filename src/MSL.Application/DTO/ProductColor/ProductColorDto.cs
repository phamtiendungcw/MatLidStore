namespace MLS.Application.DTO.ProductColor
{
    public class ProductColorDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public string ColorHexCode { get; set; } = string.Empty;
        public int ProductId { get; set; }
    }
}