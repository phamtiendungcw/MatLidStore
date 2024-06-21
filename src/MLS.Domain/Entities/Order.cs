using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; } // Date and time order was placed
        [Column(TypeName = "decimal(18,4)")] public decimal TotalPrice { get; set; } // Total order amount including discounts
        public string OrderStatus { get; set; } = string.Empty; // Order status (e.g., "Pending", "Processing", "Shipped", "Delivered")

        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } = null!; // Navigation property for User

        public List<OrderDetail> OrderDetails { get; set; } = new(); // One-to-Many relationship with OrderDetail
    }
}