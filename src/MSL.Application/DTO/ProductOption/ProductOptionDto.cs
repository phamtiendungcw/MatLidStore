namespace MLS.Application.DTO.ProductOption
{
    public class ProductOptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public int ProductId { get; set; }
    }
}