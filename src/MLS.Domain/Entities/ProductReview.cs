using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductReview : BaseEntity
    {
        public int Rating { get; set; } // Rating out of 5 stars
        public string ReviewText { get; set; } // Detailed review text
        public DateTime ReviewDate { get; set; } // Date and time review was posted

        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } // Navigation property for Product

        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } // Navigation property for User
    }
}