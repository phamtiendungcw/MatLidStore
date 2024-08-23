using System.ComponentModel.DataAnnotations;
using MLS.Domain.Common;

namespace MLS.Domain.Entities;

public class WishList : BaseEntity
{
    [MaxLength(50)] public string Name { get; set; } = string.Empty; // Wish list name (optional)

    public int UserId { get; set; } // Foreign key referencing AppUser
    public AppUser AppUser { get; set; } = null!; // Navigation property for AppUser

    public List<WishListItem> WishListItems { get; set; } = new(); // One-to-Many relationship with WishListItem
}