using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}