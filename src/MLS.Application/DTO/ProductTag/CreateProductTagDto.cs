namespace MLS.Application.DTO.ProductTag;

public class CreateProductTagDto
{
    public string TagName { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public int TagId { get; set; }
}