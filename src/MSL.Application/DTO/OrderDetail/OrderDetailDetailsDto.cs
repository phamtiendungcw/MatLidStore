using MLS.Application.DTO.Order;
using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.OrderDetail
{
    public class OrderDetailDetailsDto : OrderDetailDto
    {
        public ProductDto Product { get; set; } = new();
        public OrderDto Order { get; set; } = new();
    }
}