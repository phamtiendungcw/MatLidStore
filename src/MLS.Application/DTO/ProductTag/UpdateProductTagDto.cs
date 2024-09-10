namespace MLS.Application.DTO.ProductTag;

public class UpdateProductTagDto
{
    public int Id { get; set; }
    public string? TagName { get; set; }
    public int? ProductId { get; set; }
    public int? TagId { get; set; }
}