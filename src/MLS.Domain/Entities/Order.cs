using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public Entities.Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Entities.OrderStatus Status { get; set; }
        public List<Entities.OrderDetail> OrderDetails { get; set; }
    }
}
