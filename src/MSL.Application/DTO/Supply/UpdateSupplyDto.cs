namespace MLS.Application.DTO.Supply;

public class UpdateSupplyDto
{
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public int? SupplierId { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
}