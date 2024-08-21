using MLS.Domain.Common;

namespace MLS.Domain.Entities;

public class ShoppingCart : BaseEntity
{
    public int UserId { get; set; } // Foreign key referencing AppUser
    public AppUser AppUser { get; set; } = null!; // Navigation property for AppUser

    public List<ShoppingCartItem> ShoppingCartItems { get; set; } =
        new(); // One-to-Many relationship with ShoppingCartItem
}