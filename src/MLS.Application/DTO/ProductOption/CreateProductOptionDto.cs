namespace MLS.Application.DTO.ProductOption;

public class CreateProductOptionDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public int ProductId { get; set; }
}