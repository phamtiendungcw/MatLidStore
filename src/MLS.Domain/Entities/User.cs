using Microsoft.AspNetCore.Identity;

namespace MLS.Domain.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = string.Empty; // User's FirstName
    public string LastName { get; set; } = string.Empty; // User's LastName
    public string Phone { get; set; } = string.Empty; // User's phone number
    public bool IsDeleted { get; set; } = false;

    public ICollection<Order> Orders { get; set; } = new List<Order>(); // One-to-Many relationship with Order
    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>(); // One-to-Many relationship with ProductReview
    public ICollection<WishList> WishLists { get; set; } = new List<WishList>(); // One-to-Many relationship with WishList
    public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // One-to-Many relationship with Comment
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>(); // One-to-Many relationship with Notification
}