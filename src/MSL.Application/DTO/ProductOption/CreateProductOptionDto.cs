namespace MLS.Application.DTO.ProductOption
{
    public class CreateProductOptionDto
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int ProductId { get; set; }
    }
}