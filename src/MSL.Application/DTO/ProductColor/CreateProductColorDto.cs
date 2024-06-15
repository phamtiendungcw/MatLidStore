namespace MLS.Application.DTO.ProductColor
{
    public class CreateProductColorDto
    {
        public string ColorName { get; set; }
        public string ColorHexCode { get; set; }
        public int ProductId { get; set; }
    }
}