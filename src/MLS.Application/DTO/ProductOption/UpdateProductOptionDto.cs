namespace MLS.Application.DTO.ProductOption;

public class UpdateProductOptionDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? Value { get; set; }
    public int? ProductId { get; set; }
}