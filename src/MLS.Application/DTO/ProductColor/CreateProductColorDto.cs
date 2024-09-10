namespace MLS.Application.DTO.ProductColor;

public class CreateProductColorDto
{
    public string ColorName { get; set; } = string.Empty;
    public string ColorHexCode { get; set; } = string.Empty;
    public int ProductId { get; set; }
}