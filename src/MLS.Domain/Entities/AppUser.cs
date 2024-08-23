using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MLS.Domain.Entities;

public class AppUser : IdentityUser<int>
{
    [MaxLength(50)] public string FirstName { get; set; } = string.Empty; // AppUser's FirstName
    [MaxLength(50)] public string LastName { get; set; } = string.Empty; // AppUser's LastName
    [Phone] public string Phone { get; set; } = string.Empty; // AppUser's phone number
    public byte[]? PasswordSalt { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>(); // One-to-Many relationship with Order

    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>(); // One-to-Many relationship with ProductReview

    public ICollection<WishList> WishLists { get; set; } = new List<WishList>(); // One-to-Many relationship with WishList

    public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // One-to-Many relationship with Comment

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>(); // One-to-Many relationship with Notification

    public ICollection<AppUserRole> UserRoles { get; set; } = new List<AppUserRole>(); // One-to-Many relationship with User Role
}