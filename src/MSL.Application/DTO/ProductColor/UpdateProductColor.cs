namespace MLS.Application.DTO.ProductColor
{
    public class UpdateProductColor
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string ColorHexCode { get; set; }
        public int ProductId { get; set; }
    }
}