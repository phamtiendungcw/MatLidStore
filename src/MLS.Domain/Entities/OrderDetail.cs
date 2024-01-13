using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderDetailId { get; set; }
        public Entities.Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
