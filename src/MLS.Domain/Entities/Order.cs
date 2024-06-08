using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus? Status { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}