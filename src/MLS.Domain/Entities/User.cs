namespace MLS.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}