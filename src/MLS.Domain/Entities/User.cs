using MLS.Domain.Common;

namespace MLS.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty; // Unique username for login
    public string Email { get; set; } = string.Empty; // User's email address
    public string PasswordHash { get; set; } = string.Empty; // Hashed password for security
    public string FirstName { get; set; } = string.Empty; // User's FirstName
    public string LastName { get; set; } = string.Empty; // User's LastName
    public string Phone { get; set; } = string.Empty; // User's phone number

    public ICollection<Order> Orders { get; set; } = new List<Order>(); // One-to-Many relationship with Order
    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>(); // One-to-Many relationship with ProductReview
    public ICollection<WishList> WishLists { get; set; } = new List<WishList>(); // One-to-Many relationship with WishList
    public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // One-to-Many relationship with Comment
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>(); // One-to-Many relationship with Notification
}