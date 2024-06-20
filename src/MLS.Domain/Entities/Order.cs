using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; } // Date and time order was placed
        public decimal TotalPrice { get; set; } // Total order amount including discounts
        public string OrderStatus { get; set; } = string.Empty; // Order status (e.g., "Pending", "Processing", "Shipped", "Delivered")

        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } = null!; // Navigation property for User

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>(); // One-to-Many relationship with OrderDetail
    }
}