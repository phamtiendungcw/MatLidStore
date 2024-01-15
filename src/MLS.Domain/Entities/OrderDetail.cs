using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Entities.Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
