using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public int InventoryId { get; set; }
        public Entities.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
