using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class OrderStatus : BaseEntity
    {
        public int OrderStatusId { get; set; }
        public string StatusName { get; set; }
    }
}
