using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Domain.Entities;

public class OrderDetail : BaseEntity
{
    public int ProductId { get; set; } // Foreign key referencing Product
    public Product Product { get; set; } = null!; // Navigation property for Product

    public int Quantity { get; set; } // Quantity of the product ordered
    [Column(TypeName = "decimal(18,4)")] public decimal UnitPrice { get; set; } // UnitPrice of the product at the time of order

    public int OrderId { get; set; } // Foreign key referencing Order
    public Order Order { get; set; } = null!; // Navigation property for Order
}