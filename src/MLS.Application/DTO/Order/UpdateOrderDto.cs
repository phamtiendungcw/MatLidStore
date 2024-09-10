using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.DTO.Order;

public class UpdateOrderDto
{
    public int Id { get; set; }
    public DateTime? OrderDate { get; set; }
    public decimal? TotalPrice { get; set; }
    public string? OrderStatus { get; set; }
    public int? UserId { get; set; }
    public List<UpdateOrderDetailDto>? OrderDetails { get; set; } = new();
}