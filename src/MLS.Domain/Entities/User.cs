using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } // Unique username for login
        public string Email { get; set; } // User's email address
        public string PasswordHash { get; set; } // Hashed password for security
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; } // One-to-Many relationship with Order
        public ICollection<ProductReview> ProductReviews { get; set; } // One-to-Many relationship with ProductReview
        public ICollection<WishList> WishLists { get; set; } // One-to-Many relationship with WishList
        public ICollection<Comment> Comments { get; set; } // One-to-Many relationship with Comment
        public ICollection<Notification> Notifications { get; set; } // One-to-Many relationship with Notification
    }
}